using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public GameObject[] resourcePrefabs; // 생성할 자원 프리팹 배열
    public Transform player; // 플레이어 위치 참조
    public float spawnRadius = 10f; // 생성 반경
    public int maxResources = 5; // 한 번에 최대 생성할 자원 개수
    public float spawnInterval = 2f; // 생성 간격
    public LayerMask groundLayer; // 바닥 감지 레이어

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnResources();
            timer = 0f;
        }
    }

    void SpawnResources()
    {
        for (int i = 0; i < maxResources; i++)
        {
            Vector3 spawnPosition = GetGroundPosition();

            if (spawnPosition != Vector3.zero) // 유효한 위치 확인
            {
                GameObject resourcePrefab = resourcePrefabs[Random.Range(0, resourcePrefabs.Length)];

                // 랜덤 회전 값 생성 (Y축 기준으로 회전)
                float randomRotationY = Random.Range(0f, 360f); // 0°에서 360° 사이의 랜덤 회전
                Quaternion randomRotation = Quaternion.Euler(0f, randomRotationY, 0f);

                Instantiate(resourcePrefab, spawnPosition, randomRotation); // 랜덤 회전값으로 오브젝트 생성

                Debug.Log($"🌱 자원 생성: {resourcePrefab.name} at {spawnPosition} with rotation {randomRotationY}°"); // ✅ 생성 확인
            }
            else
            {
                Debug.LogWarning("⚠️ 유효한 바닥 위치를 찾지 못함!");
            }
        }
    }

    Vector3 GetGroundPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 startPosition = new Vector3(randomCircle.x, 10f, randomCircle.y) + player.position;

        RaycastHit hit;
        if (Physics.Raycast(startPosition, Vector3.down, out hit, 20f, groundLayer))
        {
            return hit.point;
        }

        return Vector3.zero;
    }
}
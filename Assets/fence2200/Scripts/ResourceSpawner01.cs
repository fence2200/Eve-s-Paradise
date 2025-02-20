using UnityEngine;

public class ResourceSpawner01 : MonoBehaviour
{
    public GameObject[] resourcePrefabs; // 생성할 자원 프리팹 배열
    [SerializeField] private float spawnRadius = 20f; // 자원 생성 반경
    [SerializeField] private int maxResources = 10; // 최대 자원 생성량
    private LayerMask groundLayer; // 바닥 감지 레이어(오브젝트 공중생성 방지용)
    private bool isDayEnded; // 하루 종료시 자원 다시 스폰

    void Start()
    {
        groundLayer = 1 << LayerMask.NameToLayer("Ground"); // "Ground" 레이어를 groundLayer에 할당
        isDayEnded = true;
    }

    void Update()
    {
        if (isDayEnded == true)
        {
            SpawnResources();
        }
    }

    void SpawnResources()
    {
        for (int i = 0; i < maxResources; i++) // 최대 자원 생성량 만큼
        {
            Vector3 spawnPosition = GetGroundPosition();

            if (spawnPosition != Vector3.zero) // 유효한 위치 확인
            {
                GameObject resourcePrefab = resourcePrefabs[Random.Range(0, resourcePrefabs.Length)]; // 자원 랜덤

                float randomRotationY = Random.Range(0f, 360f); // float형 0°에서 360° 사이의 랜덤값 생성(랜덤 Y값 생성)
                Quaternion randomRotation = Quaternion.Euler(0f, randomRotationY, 0f); // float인 랜덤 Y값을 Quaternion형으로 저장
                Instantiate(resourcePrefab, spawnPosition, randomRotation); // Quaternion형으로 Instantiate(오브젝트 생성)

                Debug.Log($"🌱 자원 생성: {resourcePrefab.name} at {spawnPosition} with rotation {randomRotationY}°"); // 생성 확인
            }
            else
            {
                Debug.LogWarning("⚠️ 유효한 바닥 위치를 찾지 못함!");
            }
        }
        isDayEnded = false;
    }

    Vector3 GetGroundPosition()
    {
        // 현재 오브젝트의 위치를 기준으로 반경 내에서 랜덤 위치를 계산
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius; // spawnRadius 범위 내에서 랜덤 좌표 계산
        Vector3 startPosition = new Vector3(randomCircle.x, 20f, randomCircle.y) + transform.position; // 현재 오브젝트 위치 기준으로 설정

        RaycastHit hit;
        if (Physics.Raycast(startPosition, Vector3.down, out hit, 40f, groundLayer))
        {
            return hit.point; // 바닥에 충돌한 위치 반환
        }
        return Vector3.zero; // 유효한 위치를 찾지 못하면 (0, 0, 0) 반환
    }
}

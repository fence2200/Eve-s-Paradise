using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResourceSpawner02 : MonoBehaviour // 우성님이 알려주신 스크립트
{
    public GameObject[] resourcePrefabs; // 생성할 자원 프리팹 배열
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float spawnRadius = 20f; // 자원 생성 반경
    [SerializeField] private int maxResources = 10; // 최대 자원 생성량
    [SerializeField] private int maxDistanceResources = 15; // 최대 자원 생성량
    private LayerMask groundLayer; // 바닥 감지 레이어(오브젝트 공중생성 방지용)
    [SerializeField] private bool isDayEnded; // 하루 종료시 자원 다시 스폰
    private List<GameObject> spawnList = new List<GameObject>();


    void Start()
    {
        groundLayer = 1 << LayerMask.NameToLayer("Ground"); // "Ground" 레이어를 groundLayer에 할당
        isDayEnded = true;
        InitSpawn();
        InvokeRepeating(nameof(CheckSpawner), 1f, 1f);
    }

    void InitSpawn()
    {
        if (isDayEnded == true)
        {
            SpawnResources();
        }
    }

    void SpawnResources()
    {
        if (spawnList.Count > 0)
        {
            foreach (GameObject gob in spawnList)
            {
                Destroy(gob);
            }
            spawnList.Clear();
        }
        for (int i = 0; i < maxResources; i++) // 최대 자원 생성량 만큼
        {
            Vector3 spawnPosition = GetGroundPosition();
            GameObject resourcePrefab = resourcePrefabs[Random.Range(0, resourcePrefabs.Length)]; // 자원 랜덤

            float randomRotationY = Random.Range(0f, 360f); // float형 0°에서 360° 사이의 랜덤값 생성(랜덤 Y값 생성)
            Quaternion randomRotation = Quaternion.Euler(0f, randomRotationY, 0f); // float인 랜덤 Y값을 Quaternion형으로 저장
            GameObject gob = Instantiate(resourcePrefab, spawnPosition, randomRotation); // Quaternion형으로 Instantiate(오브젝트 생성)
            gob.SetActive(false);
            spawnList.Add(gob);

            //if (spawnPosition != Vector3.zero) // 유효한 위치 확인
            //{
            //    GameObject resourcePrefab = resourcePrefabs[Random.Range(0, resourcePrefabs.Length)]; // 자원 랜덤

            //    float randomRotationY = Random.Range(0f, 360f); // float형 0°에서 360° 사이의 랜덤값 생성(랜덤 Y값 생성)
            //    Quaternion randomRotation = Quaternion.Euler(0f, randomRotationY, 0f); // float인 랜덤 Y값을 Quaternion형으로 저장
            //    Instantiate(resourcePrefab, spawnPosition, randomRotation); // Quaternion형으로 Instantiate(오브젝트 생성)

            //    Debug.Log($"🌱 자원 생성: {resourcePrefab.name} at {spawnPosition} with rotation {randomRotationY}°"); // 생성 확인
            //}
            //else
            //{
            //    Debug.LogWarning("⚠️ 유효한 바닥 위치를 찾지 못함!");
            //}
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

    void CheckSpawner()
    {
        if (!isDayEnded) return;

        foreach (GameObject gob in spawnList)
        {
            float distance = Vector3.Distance(playerTransform.position, gob.transform.position);
            bool shouldBeActive = distance < maxDistanceResources;

            // 현재 상태와 다를 때만 변경하여 불필요한 SetActive 호출 방지
            if (gob.activeSelf != shouldBeActive)
            {
                gob.SetActive(shouldBeActive);
            }
        }
    }

}
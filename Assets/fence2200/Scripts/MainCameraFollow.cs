using UnityEngine;

public class MainCameraFollow : MonoBehaviour
{
    public Transform target; // 따라갈 대상 (플레이어)
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 8, -4.8f); // 카메라 오프셋 위치값
    [SerializeField] Quaternion fixedCameraRotation = Quaternion.Euler(60f, 0f, 0f); // 카메라 오프셋 회전값
    public float smoothSpeed = 5f; // 부드러운 이동 속도

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

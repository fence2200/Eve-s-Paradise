using UnityEngine;

public class MainCameraFollow : MonoBehaviour
{
    public Transform target; // 따라갈 대상 (플레이어)
    [SerializeField] private Vector3 positionOffset = new Vector3(0, 8, -4.8f); // 카메라 오프셋
    //[SerializeField] private Vector3 inventoryOffset = new Vector3(1.6f , 8, -4.8f); // 인벤토리가 열릴 때 카메라 오프셋
    [SerializeField] private Vector3 rotationOffset = new Vector3(60f, 0f, 0f); // 카메라 로테이션 오프셋
    public float smoothSpeed = 5f; // 부드러운 이동 속도
    private Quaternion fixedCameraRotation;
    public InventoryController inventoryController; // InventoryController 참조
    

    void Start()
    {
        fixedCameraRotation = Quaternion.Euler(rotationOffset); // Vector3 → Quaternion 변환
    }

    void LateUpdate() // LateUpdate에서 위치 업데이트
    {
        if (target == null) return; // target이 없으면 실행 X

        if(inventoryController.isInventoryOpen == true)
        {
            // 목표 위치 계산
            Vector3 desiredPosition = target.position + new Vector3(positionOffset.x + 1.6f, positionOffset.y, positionOffset.z);
            // 부드럽게 이동
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            // 고정된 회전 적용
            transform.rotation = fixedCameraRotation;
        }
        else
        {
            // 목표 위치 계산
            Vector3 desiredPosition = target.position + positionOffset;
            // 부드럽게 이동
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            // 고정된 회전 적용
            transform.rotation = fixedCameraRotation;
        }
    }
}
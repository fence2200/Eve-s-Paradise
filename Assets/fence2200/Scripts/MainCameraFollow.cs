using UnityEngine;

public class MainCameraFollow : MonoBehaviour
{
    public Transform target; // ���� ��� (�÷��̾�)
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 8, -4.8f); // ī�޶� ������ ��ġ��
    [SerializeField] Quaternion fixedCameraRotation = Quaternion.Euler(60f, 0f, 0f); // ī�޶� ������ ȸ����
    public float smoothSpeed = 5f; // �ε巯�� �̵� �ӵ�

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

public class MainCameraFollow : MonoBehaviour
{
    public Transform target; // ���� ��� (�÷��̾�)
    [SerializeField] private Vector3 positionOffset = new Vector3(0, 8, -4.8f); // ī�޶� ������ ������
    [SerializeField] private Vector3 rotationOffset = new Vector3(60f, 0f, 0f); // ī�޶� �����̼� ������
    public float smoothSpeed = 5f; // �ε巯�� �̵� �ӵ�

    private Quaternion fixedCameraRotation;

    void Start()
    {
        fixedCameraRotation = Quaternion.Euler(rotationOffset); // Vector3 �� Quaternion ��ȯ
    }

    void LateUpdate() // LateUpdate���� ��ġ ������Ʈ
    {
        if (target == null) return; // target�� ������ ���� X

        // ��ǥ ��ġ ���
        Vector3 desiredPosition = target.position + positionOffset;
        // �ε巴�� �̵�
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        // ������ ȸ�� ����
        transform.rotation = fixedCameraRotation;
    }
}

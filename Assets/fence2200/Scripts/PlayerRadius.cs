using UnityEngine;

public class PlayerRadius : MonoBehaviour
{
    public float radius = 15f; // �÷��̾��� �ݰ� ũ��
    public Color radiusColor = Color.green; // �ݰ��� ����

    void OnDrawGizmos()
    {
        // �ݰ��� ���� ����
        Gizmos.color = radiusColor;

        // �ݰ濡 �ش��ϴ� ���� �׷��� (transform.position�� �������� �ݰ��� �׸���)
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

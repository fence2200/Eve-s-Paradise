using UnityEngine;

public class PlayerRadius : MonoBehaviour
{
    public float radius = 15f; // 플레이어의 반경 크기
    public Color radiusColor = Color.green; // 반경의 색상

    void OnDrawGizmos()
    {
        // 반경의 색상 설정
        Gizmos.color = radiusColor;

        // 반경에 해당하는 원을 그려줌 (transform.position을 기준으로 반경을 그린다)
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

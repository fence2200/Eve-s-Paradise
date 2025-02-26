using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 싱글턴 인스턴스

    public ItemContainer inventory; // 인벤토리 데이터

    private void Awake()
    {
        // 싱글턴 패턴 적용
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
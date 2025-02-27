using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private Item item; // 줍는 아이템
    [SerializeField] private int itemCount = 1; // 아이템 개수

    private void OnMouseDown() // 마우스 클릭 시 아이템 줍기
    {
        GameManager.Instance.inventory.AddItem(item, itemCount); // 인벤토리에 아이템 추가
        Destroy(gameObject); // 아이템 오브젝트 삭제
    }
}
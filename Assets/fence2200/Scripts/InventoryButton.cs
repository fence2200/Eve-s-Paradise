using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] private Image icon;
    private Item item;

    // 아이템 설정
    public void SetItem(ItemContainer.ItemSlot slot)
    {
        item = slot.item;

        if (item != null && icon != null)
        {
            icon.sprite = item.icon; // 아이템의 아이콘을 설정
            icon.color = Color.white; // 아이콘 색을 흰색으로 설정 (보이게)
        }
        else
        {
            Debug.LogError("아이템이나 아이콘이 설정되지 않았습니다.");
        }
    }

    // 아이템을 비우는 함수
    public void Clear()
    {
        item = null;
        icon.sprite = null; // 아이콘을 비움
        icon.color = new Color(1, 1, 1, 0); // 아이콘을 투명하게 처리
    }
}
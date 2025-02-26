using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private ItemContainer inventory; // 인벤토리 데이터
    [SerializeField] private List<InventoryButton> buttons; // UI 버튼들

    private void OnEnable()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i < inventory.slots.Count && inventory.slots[i].item != null)
            {
                buttons[i].SetItem(inventory.slots[i]); // 아이템 표시
            }
            else
            {
                buttons[i].Clear(); // 빈 슬롯으로 변경
            }
        }
    }
}
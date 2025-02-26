using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/ItemContainer")]
public class ItemContainer : ScriptableObject
{
    [System.Serializable]
    public class ItemSlot
    {
        public Item item;
        public int count;
    }

    public List<ItemSlot> slots = new List<ItemSlot>(); // 아이템 리스트

    // 아이템 추가 함수
    public void AddItem(Item item, int count = 1)
    {
        // 스택 가능한 아이템이면 기존 슬롯 찾기
        if (item.stackable)
        {
            ItemSlot existingSlot = slots.Find(slot => slot.item == item);
            if (existingSlot != null)
            {
                existingSlot.count += count;
                return;
            }
        }

        // 새 슬롯 추가
        slots.Add(new ItemSlot { item = item, count = count });
    }
}
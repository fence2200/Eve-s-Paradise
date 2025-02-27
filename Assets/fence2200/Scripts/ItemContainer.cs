using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/ItemContainer")]
public class ItemContainer : ScriptableObject
{
    [System.Serializable]
    public class ItemSlot
    {
        public Item item;
        public int count;
    }

    public List<ItemSlot> slots = new List<ItemSlot>(); // 아이템 슬롯들

    // 아이템 추가 함수
    public void AddItem(Item item, int count = 1)
    {
        if (item.stackable)
        {
            // 스택 가능한 아이템이면 기존 슬롯 찾기
            ItemSlot existingSlot = slots.Find(slot => slot.item == item);
            if (existingSlot != null)
            {
                existingSlot.count += count; // 기존 슬롯에 개수 더하기
                return;
            }
        }

        // 새 슬롯에 아이템 추가
        slots.Add(new ItemSlot { item = item, count = count });
    }

    // 아이템 삭제 함수
    public void RemoveItem(Item item, int count = 1)
    {
        ItemSlot existingSlot = slots.Find(slot => slot.item == item);
        if (existingSlot != null)
        {
            existingSlot.count -= count;
            if (existingSlot.count <= 0)
                slots.Remove(existingSlot);
        }
    }
}
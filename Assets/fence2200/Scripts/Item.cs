using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName; // 아이템 이름
    public Sprite icon; // 아이템 아이콘
    public bool stackable; // 스택 가능 여부
}
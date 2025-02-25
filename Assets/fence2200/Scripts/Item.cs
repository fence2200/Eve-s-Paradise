using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Data/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public bool stackable;
}
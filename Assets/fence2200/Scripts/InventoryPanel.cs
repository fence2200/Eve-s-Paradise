using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField]
    ItemContainer inventory;
    [SerializeField]
    List<InventoryButton> inventoryButtons;

    private void Start()
    {
        inventoryButtons.AddRange(this.transform.GetComponentsInChildren<InventoryButton>());
        SetIndex();
        Show();
    }

    private void SetIndex()
    {
        Debug.Log(inventory.slots.Count);
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            inventoryButtons[i].SetIndex(i);
        }
    }

    private void Show()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i].item != null)
            {
                inventoryButtons[i].SetItem(inventory.slots[i]);
            }
            else
            {
                inventoryButtons[i].Clean();
            }
        }
    }
}
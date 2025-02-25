using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryPanel;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
        }    
    }
}

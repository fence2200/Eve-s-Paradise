using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    public GameObject inventoryPanel;

    public bool isInventoryOpen = false;  // 인벤토리 열림 상태를 추적하는 변수

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            // 인벤토리 상태 토글
            inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);

            // 인벤토리가 열리면 isInventoryOpen을 true, 닫히면 false로 설정
            isInventoryOpen = inventoryPanel.activeInHierarchy;
        }
    }
}
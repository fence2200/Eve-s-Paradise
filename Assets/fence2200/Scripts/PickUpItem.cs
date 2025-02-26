using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Item item;
    public int count = 1;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) // 좌클릭(0번 버튼)
        {
            Pickup();
        }
    }

    private void Pickup()
    {
        if (GameManager.Instance.inventory != null)
        {
            GameManager.Instance.inventory.AddItem(item, count);
            Destroy(gameObject); // 아이템 삭제
        }
        else
        {
            Debug.LogWarning("GameManager의 inventory가 설정되지 않음!");
        }
    }
}
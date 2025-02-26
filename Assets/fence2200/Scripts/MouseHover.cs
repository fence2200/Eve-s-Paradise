using UnityEngine;
using TMPro;

public class MouseHover : MonoBehaviour
{
    public LayerMask resourceLayer; // 자원 레이어
    public GameObject resourceCanvas; // 자원 캔버스
    private GameObject currentCanvas; // 현재 텍스트 저장용
    public Transform uIManager; // 텍스트 생성시 이 오브젝트의 자식으로
    private Camera mainCamera; // Ray사용을 위한 카메라

    public ItemContainer inventoryContainer; // 인벤토리 데이터 참조
    public Item branchItem; // 나뭇가지 아이템 (인벤토리에 추가할 아이템)

    void Start()
    {
        mainCamera = Camera.main; // 카메라 캐싱
    }

    void Update()
    {
        HandleMouseHover();
        HandleMouseClick(); // 클릭 감지 추가
    }

    void HandleMouseHover()
    {
        if (Camera.main == null)
        {
            Debug.LogError("❌ Main Camera가 씬에 없습니다!");
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f, resourceLayer)) // 10f로 범위 제한
        {
            if (hit.transform.CompareTag("Branch")) // "Branch" 태그 확인
            {
                if (currentCanvas == null) // 텍스트가 없으면 생성
                {
                    currentCanvas = Instantiate(resourceCanvas, hit.transform.position + new Vector3(0, 0.3f, 0), Quaternion.Euler(80f, 0f, 0f));
                    currentCanvas.transform.SetParent(uIManager);

                    TextMeshProUGUI textMeshProUGUI = currentCanvas.GetComponentInChildren<TextMeshProUGUI>();

                    if (textMeshProUGUI == null)
                    {
                        Debug.LogError("❌ textMeshPro를 찾을수 없습니다!");
                        return;
                    }

                    textMeshProUGUI.text = "나뭇가지";
                }
            }
        }
        else
        {
            if (currentCanvas != null)
            {
                Destroy(currentCanvas);
            }
        }
    }

    void HandleMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) // 좌클릭 감지
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10f, resourceLayer)) // 다시 Raycast 체크
            {
                if (hit.transform.CompareTag("Branch")) // "Branch" 태그 확인
                {
                    // 인벤토리에 아이템 추가
                    inventoryContainer.AddItem(branchItem, 1);

                    Destroy(hit.transform.gameObject); // 클릭한 나뭇가지 삭제
                }
            }
        }
    }
}
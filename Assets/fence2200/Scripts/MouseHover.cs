using UnityEngine;
using TMPro;

public class MouseHover : MonoBehaviour
{
    public LayerMask resourceLayer; // 자원 레이어
    public GameObject resourceCanvas; // 자원 캔버스
    private GameObject currentCanvas; // 현재 텍스트 저장용
    public Transform uIManager; // 텍스트 생성시 이 오브젝트의 자식으로
    private Camera mainCamera; // Ray사용을 위한 카메라

    void Start()
    {
        mainCamera = Camera.main; // 카메라 캐싱
    }

    void Update()
    {
        HandleMouseHover();
    }

    void HandleMouseHover()
    {
        if (Camera.main == null)
        {
            Debug.LogError("❌ Main Camera가 씬에 없습니다!");
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스 위치에서 Raycast를 쏴서 나뭇가지 위에 있는지 확인
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, resourceLayer)) // Ray 사정거리 지정과 지정된 자원 레이어만 체크
        {
            if (hit.transform.CompareTag("Branch")) // 나뭇가지 태그가 붙어 있으면
            {
                if (currentCanvas == null) // 텍스트가 없으면 생성
                {
                    currentCanvas = Instantiate(resourceCanvas, hit.transform.position + new Vector3(0, 0.3f, 0), Quaternion.Euler(80f, 0f, 0f)); // 나뭇가지의 위치에 텍스트 캔버스를 생성
                    currentCanvas.transform.SetParent(uIManager); // uIManager의 자식으로 설정

                    TextMeshProUGUI textMeshProUGUI = currentCanvas.GetComponentInChildren<TextMeshProUGUI>(); // currentCanvas에서 자식의 TextMeshProUGUI

                    if (textMeshProUGUI == null)
                    {
                        Debug.LogError("❌ textMeshPro를 찾을수 없습니다!");
                        return;
                    }

                    textMeshProUGUI.text = "나뭇가지"; // 텍스트 설정
                }
            }
        }
        else
        {
            // 마우스가 나뭇가지에서 벗어나면 텍스트 삭제
            if (currentCanvas != null)
            {
                Destroy(currentCanvas);
            }
        }
    }
}

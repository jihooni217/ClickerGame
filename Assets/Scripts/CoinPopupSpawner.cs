using UnityEngine;
using UnityEngine.EventSystems;

public class CoinPopupSpawner : MonoBehaviour
{
    public GameObject coinPopupPrefab;  // 코인 팝업 프리팹
    public Canvas canvas;               // UI 캔버스
    public RectTransform canvasRect;    // 캔버스의 RectTransform

    // 골드 수치 (지금은 임시값, 나중에 외부에서 받아와도 됨)
    public int currentGoldAmount = 100;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // UI 위 클릭 무시
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Vector2 screenPos = Input.mousePosition;
            Vector2 anchoredPos;

            // 화면 좌표 → 캔버스 UI 좌표
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                screenPos,
                canvas.worldCamera,
                out anchoredPos
            );

            // 팝업 생성
            GameObject popup = Instantiate(coinPopupPrefab, canvas.transform);
            popup.GetComponent<RectTransform>().anchoredPosition = anchoredPos;

            // 골드 텍스트 설정
            FloatingPopup floating = popup.GetComponent<FloatingPopup>();
            floating.SetGoldAmount(currentGoldAmount);
        }
    }
}

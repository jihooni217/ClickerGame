using UnityEngine;
using UnityEngine.EventSystems;

public class CoinPopupSpawner : MonoBehaviour
{
    public GameObject coinPopupPrefab;  // ���� �˾� ������
    public Canvas canvas;               // UI ĵ����
    public RectTransform canvasRect;    // ĵ������ RectTransform

    // ��� ��ġ (������ �ӽð�, ���߿� �ܺο��� �޾ƿ͵� ��)
    public int currentGoldAmount = 100;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // UI �� Ŭ�� ����
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Vector2 screenPos = Input.mousePosition;
            Vector2 anchoredPos;

            // ȭ�� ��ǥ �� ĵ���� UI ��ǥ
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                screenPos,
                canvas.worldCamera,
                out anchoredPos
            );

            // �˾� ����
            GameObject popup = Instantiate(coinPopupPrefab, canvas.transform);
            popup.GetComponent<RectTransform>().anchoredPosition = anchoredPos;

            // ��� �ؽ�Ʈ ����
            FloatingPopup floating = popup.GetComponent<FloatingPopup>();
            floating.SetGoldAmount(currentGoldAmount);
        }
    }
}

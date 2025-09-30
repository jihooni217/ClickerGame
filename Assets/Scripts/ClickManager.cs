using UnityEngine;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour
{
    public Animator lumberjackAnimator;
    public GameObject coinPopupPrefab;
    public Canvas uiCanvas;
    public Transform canvasTransform;

    private void Update()
    {
        // UI 위 클릭은 무시
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            PlayLumberjackAnimation();
            Vector3 clickPosition = Input.mousePosition;
            ShowCoinPopup(clickPosition);
            CoinManager.Instance.AddCoin(CoinManager.Instance.coinPerClick);
        }
    }


    void PlayLumberjackAnimation()
    {
        if (lumberjackAnimator != null)
        {
            lumberjackAnimator.SetTrigger("Chop");
        }
    }

    void ShowCoinPopup(Vector3 screenPosition)
    {
        if (coinPopupPrefab != null && uiCanvas != null)
        {
            GameObject popup = Instantiate(coinPopupPrefab, uiCanvas.transform);
            RectTransform rect = popup.GetComponent<RectTransform>();

            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                uiCanvas.transform as RectTransform, screenPosition, uiCanvas.worldCamera, out localPoint
            );

            rect.localPosition = localPoint;

            CoinPopup popupScript = popup.GetComponent<CoinPopup>();
            if (popupScript != null)
            {
                popupScript.SetText(CoinManager.Instance.coinPerClick);
            }
        }
    }
}

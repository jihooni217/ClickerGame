using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator woodcutterAnimator;
    public GameObject coinPopupPrefab;
    public Canvas mainCanvas;
    public int coinPerClick = 10;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Input.mousePosition;

            // 1. 애니메이션 재생
            woodcutterAnimator.SetTrigger("Chop");

            // 2. 코인 증가
            CoinManager.Instance.AddCoin(coinPerClick);

            // 3. 팝업 생성
            GameObject popup = Instantiate(coinPopupPrefab, mainCanvas.transform);
            popup.transform.position = clickPosition;

            // 코인 수 표시
            popup.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "+" + coinPerClick.ToString();
        }
    }
}

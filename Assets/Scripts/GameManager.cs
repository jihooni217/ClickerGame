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

            // 1. �ִϸ��̼� ���
            woodcutterAnimator.SetTrigger("Chop");

            // 2. ���� ����
            CoinManager.Instance.AddCoin(coinPerClick);

            // 3. �˾� ����
            GameObject popup = Instantiate(coinPopupPrefab, mainCanvas.transform);
            popup.transform.position = clickPosition;

            // ���� �� ǥ��
            popup.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "+" + coinPerClick.ToString();
        }
    }
}

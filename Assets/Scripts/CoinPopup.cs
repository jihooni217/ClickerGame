using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinPopup : MonoBehaviour
{
    public TextMeshProUGUI popupText;
    public Image popupImage;

    public float moveSpeed = 50f;
    public float fadeSpeed = 2f;

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    void Update()
    {
        // 위로 이동
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // 서서히 사라짐
        canvasGroup.alpha -= fadeSpeed * Time.deltaTime;

        if (canvasGroup.alpha <= 0)
            Destroy(gameObject);
    }

    /// 여기에 SetText 메서드를 정의해줘!
    public void SetText(int amount)
    {
        if (popupText != null)
        {
            popupText.text = amount + "G";
        }
    }
}

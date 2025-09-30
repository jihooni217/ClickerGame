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
        // ���� �̵�
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // ������ �����
        canvasGroup.alpha -= fadeSpeed * Time.deltaTime;

        if (canvasGroup.alpha <= 0)
            Destroy(gameObject);
    }

    /// ���⿡ SetText �޼��带 ��������!
    public void SetText(int amount)
    {
        if (popupText != null)
        {
            popupText.text = amount + "G";
        }
    }
}

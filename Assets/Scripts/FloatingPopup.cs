using UnityEngine;
using TMPro;

public class FloatingPopup : MonoBehaviour
{
    public float floatDistance = 50f;
    public float duration = 0.8f;

    private Vector3 startPos;
    private Vector3 endPos;
    private float timer = 0f;
    private CanvasGroup canvasGroup;

    // 외부에서 텍스트 설정용
    public TextMeshProUGUI goldText;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(0, floatDistance, 0);
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        float t = timer / duration;

        // 위로 떠오르기
        transform.position = Vector3.Lerp(startPos, endPos, t);
        // 점점 사라지기
        canvasGroup.alpha = 1f - t;

        if (t >= 1f)
        {
            Destroy(gameObject);
        }
    }

    // 외부에서 골드 텍스트 설정해주는 함수
    public void SetGoldAmount(int amount)
    {
        if (goldText != null)
        {
            goldText.text = amount.ToString() + "G";
        }
    }
}

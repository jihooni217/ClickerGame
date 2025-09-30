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

    // �ܺο��� �ؽ�Ʈ ������
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

        // ���� ��������
        transform.position = Vector3.Lerp(startPos, endPos, t);
        // ���� �������
        canvasGroup.alpha = 1f - t;

        if (t >= 1f)
        {
            Destroy(gameObject);
        }
    }

    // �ܺο��� ��� �ؽ�Ʈ �������ִ� �Լ�
    public void SetGoldAmount(int amount)
    {
        if (goldText != null)
        {
            goldText.text = amount.ToString() + "G";
        }
    }
}

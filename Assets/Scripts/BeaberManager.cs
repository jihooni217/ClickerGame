using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class AutoHunterManager : MonoBehaviour
{
    [Header("��� ���� UI")]
    public Button beaverButton;
    public TextMeshProUGUI beaverInfoText;
    public TextMeshProUGUI beaverButtonText;
    public GameObject beaverImage;

    private int beaverLevel = 0;
    private int beaverBaseCost = 80;
    private float beaverCostMultiplier = 1.3f;
    private int beaverCurrentCost;

    private Coroutine beaverCoroutine;

    void Start()
    {
        beaverCurrentCost = beaverBaseCost;
        UpdateBeaverUI();
        beaverImage.SetActive(false);  // ó���� �̹��� ����

        beaverButton.onClick.AddListener(OnBeaverPurchase);
    }

    void OnBeaverPurchase()
    {
        if (CoinManager.Instance.CurrentCoin >= beaverCurrentCost)
        {
            // ���� ����, ���� ����
            CoinManager.Instance.SpendCoin(beaverCurrentCost);
            beaverLevel++;
            beaverCurrentCost = Mathf.RoundToInt(beaverBaseCost * Mathf.Pow(beaverCostMultiplier, beaverLevel));

            // �ڵ� ���� ����
            if (beaverLevel == 1)
            {
                beaverCoroutine = StartCoroutine(BeaverAutoCollect());
                beaverImage.SetActive(true);
            }

            UpdateBeaverUI();
        }
        else
        {
            Debug.Log("��� ��ɲ��� ������ ��尡 ������!");
        }
    }

    IEnumerator BeaverAutoCollect()
    {
        while (true)
        {
            int income = Mathf.RoundToInt(10 * Mathf.Pow(1.5f, beaverLevel - 1));
            CoinManager.Instance.AddCoin(income);
            yield return new WaitForSeconds(1f);
        }
    }

    void UpdateBeaverUI()
    {
        beaverInfoText.text = $"Lv. {beaverLevel}";
        beaverButtonText.text = $"{beaverCurrentCost}G";
    }
}
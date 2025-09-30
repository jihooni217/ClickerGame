using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class AutoHunterManager : MonoBehaviour
{
    [Header("비버 관련 UI")]
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
        beaverImage.SetActive(false);  // 처음엔 이미지 숨김

        beaverButton.onClick.AddListener(OnBeaverPurchase);
    }

    void OnBeaverPurchase()
    {
        if (CoinManager.Instance.CurrentCoin >= beaverCurrentCost)
        {
            // 코인 차감, 레벨 증가
            CoinManager.Instance.SpendCoin(beaverCurrentCost);
            beaverLevel++;
            beaverCurrentCost = Mathf.RoundToInt(beaverBaseCost * Mathf.Pow(beaverCostMultiplier, beaverLevel));

            // 자동 수익 시작
            if (beaverLevel == 1)
            {
                beaverCoroutine = StartCoroutine(BeaverAutoCollect());
                beaverImage.SetActive(true);
            }

            UpdateBeaverUI();
        }
        else
        {
            Debug.Log("비버 사냥꾼을 구매할 골드가 부족해!");
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
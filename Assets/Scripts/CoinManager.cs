using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    public int clickLevel = 1; // 기본 클릭 레벨은 1부터 시작

    public int CurrentCoin = 0;
    public int coinPerClick = 1; // 클릭당 획득 코인 수
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateCoinUI();
    }

    public void AddCoin(int amount)
    {
        CurrentCoin += amount;
        UpdateCoinUI();
    }

    public void SpendCoin(int amount)
    {
        CurrentCoin -= amount;
        if (CurrentCoin < 0) CurrentCoin = 0;
        UpdateCoinUI();
    }

    public void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = CurrentCoin + "G";
        }
    }

    // 업그레이드할 때 coinPerClick을 증가시킴
    public void UpgradeCoinPerClick(int amount)
    {
        coinPerClick += amount;
    }

    // 현재 클릭당 코인 반환 (ClickManager에서 사용)
    public int GetCoinPerClick()
    {
        return coinPerClick;
    }
}

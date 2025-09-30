using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    public int clickLevel = 1; // �⺻ Ŭ�� ������ 1���� ����

    public int CurrentCoin = 0;
    public int coinPerClick = 1; // Ŭ���� ȹ�� ���� ��
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

    // ���׷��̵��� �� coinPerClick�� ������Ŵ
    public void UpgradeCoinPerClick(int amount)
    {
        coinPerClick += amount;
    }

    // ���� Ŭ���� ���� ��ȯ (ClickManager���� ���)
    public int GetCoinPerClick()
    {
        return coinPerClick;
    }
}

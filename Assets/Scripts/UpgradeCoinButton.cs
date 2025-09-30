using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UpgradeCoinButton : MonoBehaviour
{
    public int baseCost = 10;             // ���� ���
    public float costMultiplier = 1.5f;   // �� ���׷��̵帶�� ��� ���� ����
    public int upgradeAmount = 1;         // Ŭ���� ���� ������

    private int currentLevel = 0;         // ���׷��̵� Ƚ��
    private int currentCost;              // ���� ���

    public TextMeshProUGUI costText;                 // UI�� ��� ǥ���� �ؽ�Ʈ
    public TextMeshProUGUI levelText;                // UI�� ���� ���� ǥ���� �ؽ�Ʈ

    private ClickManager clickManager;

    private void Start()
    {
        currentCost = baseCost;

        clickManager = FindAnyObjectByType<ClickManager>();

        UpdateUI();
    }

    public void OnUpgradeClick()
    {
        if (CoinManager.Instance.CurrentCoin >= currentCost)
        {
            CoinManager.Instance.SpendCoin(currentCost);
            CoinManager.Instance.UpgradeCoinPerClick(upgradeAmount);

            currentLevel++;
            currentCost = Mathf.RoundToInt(baseCost * Mathf.Pow(costMultiplier, currentLevel)); // ��� ���� ����

            UpdateUI();
            Debug.Log("���׷��̵� ����! ���� ȹ�淮: " + CoinManager.Instance.GetCoinPerClick());
        }
        else
        {
            Debug.Log("������ �����ؿ�!");
        }
    }

    private void UpdateUI()
    {
        if (costText != null)
            costText.text = currentCost + "G";

        if (levelText != null)
            levelText.text = "Gold Lv. " + currentLevel;
    }
    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}


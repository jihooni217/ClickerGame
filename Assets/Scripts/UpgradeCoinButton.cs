using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UpgradeCoinButton : MonoBehaviour
{
    public int baseCost = 10;             // 시작 비용
    public float costMultiplier = 1.5f;   // 매 업그레이드마다 비용 증가 비율
    public int upgradeAmount = 1;         // 클릭당 코인 증가량

    private int currentLevel = 0;         // 업그레이드 횟수
    private int currentCost;              // 현재 비용

    public TextMeshProUGUI costText;                 // UI에 비용 표시할 텍스트
    public TextMeshProUGUI levelText;                // UI에 현재 레벨 표시할 텍스트

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
            currentCost = Mathf.RoundToInt(baseCost * Mathf.Pow(costMultiplier, currentLevel)); // 비용 증가 공식

            UpdateUI();
            Debug.Log("업그레이드 성공! 현재 획득량: " + CoinManager.Instance.GetCoinPerClick());
        }
        else
        {
            Debug.Log("코인이 부족해요!");
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


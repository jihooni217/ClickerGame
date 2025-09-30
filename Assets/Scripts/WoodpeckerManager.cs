using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class WoodpeckerAutoManager : MonoBehaviour
{
    [Header("딱따구리 관련 UI")]
    public Button woodpeckerButton;
    public TextMeshProUGUI woodpeckerInfoText;
    public TextMeshProUGUI woodpeckerButtonText;
    public GameObject woodpeckerImage; // 딱따구리 애니메이터

    [Header("게임 클리어 관련")]
    public GameObject GameClearPanel;  // 추가: GameClearPanel을 연결할 수 있게

    private int woodpeckerLevel = 0;
    private int woodpeckerBaseCost = 4500;
    private float woodpeckerCostMultiplier = 1.2f;
    private int woodpeckerCurrentCost;
    private int maxWoodpeckerLevel = 5;  // 추가: 최대 레벨 설정


    private Coroutine woodpeckerCoroutine;

    void Start()
    {
        woodpeckerCurrentCost = woodpeckerBaseCost;
        UpdateWoodpeckerUI();
        woodpeckerImage.SetActive(false);  // 처음엔 이미지 숨김
        GameClearPanel.SetActive(false);   // 처음엔 숨겨둠


        woodpeckerButton.onClick.AddListener(OnWoodpeckerPurchase);
    }

    void OnWoodpeckerPurchase()
    {
        if (CoinManager.Instance.CurrentCoin >= woodpeckerCurrentCost)
        {
            CoinManager.Instance.SpendCoin(woodpeckerCurrentCost);
            woodpeckerLevel++;
            woodpeckerCurrentCost = Mathf.RoundToInt(woodpeckerBaseCost * Mathf.Pow(woodpeckerCostMultiplier, woodpeckerLevel));

            if (woodpeckerLevel == 1)
            {
                woodpeckerCoroutine = StartCoroutine(WoodpeckerAutoCollect());
                woodpeckerImage.SetActive(true);
            }

            if (woodpeckerLevel >= maxWoodpeckerLevel)
            {
                Debug.Log("게임 클리어!");
                GameClearPanel.SetActive(true); // GAME CLEAR 화면 활성화
            }

            UpdateWoodpeckerUI();
        }
        else
        {
            Debug.Log("딱따구리를 구매할 골드가 부족해!");
        }
    }

    IEnumerator WoodpeckerAutoCollect()
    {
        while (true)
        {
            int income = Mathf.RoundToInt(100 * Mathf.Pow(1.6f, woodpeckerLevel - 1));
            CoinManager.Instance.AddCoin(income);
            yield return new WaitForSeconds(1f);
        }
    }

    void UpdateWoodpeckerUI()
    {
        woodpeckerInfoText.text = $"Lv. {woodpeckerLevel}";
        woodpeckerButtonText.text = $"{woodpeckerCurrentCost}G";
    }
}

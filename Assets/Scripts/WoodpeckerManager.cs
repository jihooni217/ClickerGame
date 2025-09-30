using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class WoodpeckerAutoManager : MonoBehaviour
{
    [Header("�������� ���� UI")]
    public Button woodpeckerButton;
    public TextMeshProUGUI woodpeckerInfoText;
    public TextMeshProUGUI woodpeckerButtonText;
    public GameObject woodpeckerImage; // �������� �ִϸ�����

    [Header("���� Ŭ���� ����")]
    public GameObject GameClearPanel;  // �߰�: GameClearPanel�� ������ �� �ְ�

    private int woodpeckerLevel = 0;
    private int woodpeckerBaseCost = 4500;
    private float woodpeckerCostMultiplier = 1.2f;
    private int woodpeckerCurrentCost;
    private int maxWoodpeckerLevel = 5;  // �߰�: �ִ� ���� ����


    private Coroutine woodpeckerCoroutine;

    void Start()
    {
        woodpeckerCurrentCost = woodpeckerBaseCost;
        UpdateWoodpeckerUI();
        woodpeckerImage.SetActive(false);  // ó���� �̹��� ����
        GameClearPanel.SetActive(false);   // ó���� ���ܵ�


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
                Debug.Log("���� Ŭ����!");
                GameClearPanel.SetActive(true); // GAME CLEAR ȭ�� Ȱ��ȭ
            }

            UpdateWoodpeckerUI();
        }
        else
        {
            Debug.Log("���������� ������ ��尡 ������!");
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

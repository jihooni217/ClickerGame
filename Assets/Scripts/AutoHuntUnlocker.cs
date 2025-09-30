using UnityEngine;
using UnityEngine.UI;

public class AutoAttackUnlockManager : MonoBehaviour
{
    public UpgradeCoinButton upgradeCoinButton;

    public GameObject beaverLockOverlay;
    public Button beaverButton;

    public GameObject woodpeckerLockOverlay;
    public Button woodpeckerButton;

    private void Update()
    {
        int currentLevel = upgradeCoinButton.GetCurrentLevel();

        if (currentLevel >= 5 && beaverLockOverlay.activeSelf)
        {
            beaverLockOverlay.SetActive(false);
            beaverButton.interactable = true;
            Debug.Log("비버 자동사냥 해금!");
        }

        if (currentLevel >= 15 && woodpeckerLockOverlay.activeSelf)
        {
            woodpeckerLockOverlay.SetActive(false);
            woodpeckerButton.interactable = true;
            Debug.Log("딱따구리 자동사냥 해금!");
        }
    }
}

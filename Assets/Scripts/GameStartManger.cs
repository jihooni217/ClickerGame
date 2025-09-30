using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public GameObject GameStartPanel;  // 시작 화면 패널

    public void OnStartButtonClicked()
    {
        GameStartPanel.SetActive(false);  // 게임 시작 시 패널 숨기기
        Time.timeScale = 1f;          // 혹시 정지되어 있다면 시간도 정상으로
    }
}

using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public GameObject GameStartPanel;  // ���� ȭ�� �г�

    public void OnStartButtonClicked()
    {
        GameStartPanel.SetActive(false);  // ���� ���� �� �г� �����
        Time.timeScale = 1f;          // Ȥ�� �����Ǿ� �ִٸ� �ð��� ��������
    }
}

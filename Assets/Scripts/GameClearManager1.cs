using UnityEngine;
using UnityEngine.SceneManagement;  // ���� �ٽ� �ε��ϱ� ���� �ʿ�

public class GameClearManager : MonoBehaviour
{
    public void RestartGame()
    {
        // ���� �� �ٽ� �ε�
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

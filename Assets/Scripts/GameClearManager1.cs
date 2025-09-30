using UnityEngine;
using UnityEngine.SceneManagement;  // 씬을 다시 로드하기 위해 필요

public class GameClearManager : MonoBehaviour
{
    public void RestartGame()
    {
        // 현재 씬 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverScreen;

    [SerializeField]
    private GameObject _winScreen;

    public TMP_Text LivesText;
    public int Lives = 3;

    public void Win()
    {
        Time.timeScale = 0;
        _winScreen.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

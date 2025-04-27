using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] TMP_Text gameOverScoreText;
    [SerializeField] TMP_Text highcoreText;

    public void UpdateScore(int score)
    {
        scoreText.text = $"{score}";
    }

    public void OnRestartClicked()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnMainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnGameOver(int score, int highscore)
    {
        scoreText.gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
        gameOverScoreText.text = $"SCORE: {score}";
        highcoreText.text = $"HIGHSCORE: {highscore}";
    }
}

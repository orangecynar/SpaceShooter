using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject topPanel;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] TMP_Text gameOverScoreText;
    [SerializeField] TMP_Text highcoreText;
    [SerializeField] Image pauseButtonImage;
    [SerializeField] Sprite playButtonSprite;
    [SerializeField] Sprite pauseButtonSprite;
    bool gamePaused = false;

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

    public void OnPauseClicked()
    {
        gamePaused = !gamePaused;

        if (gamePaused)
        {
            Time.timeScale = 0.0f;
            pauseButtonImage.sprite = playButtonSprite;
        }
        else
        {
            Time.timeScale = 1.0f;
            pauseButtonImage.sprite = pauseButtonSprite;
        }
    }

    public void OnGameOver(int score, int highscore)
    {
        topPanel.SetActive(false);
        gameOverMenu.SetActive(true);
        gameOverScoreText.text = $"SCORE: {score}";
        highcoreText.text = $"HIGHSCORE: {highscore}";
    }
}

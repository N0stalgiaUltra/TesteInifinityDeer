using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText, scoreText, highScoreText;
    [SerializeField] private Button retryButton;

    private void Start()
    {
        retryButton.onClick.AddListener(ReloadScene);
    }
    public void SetGameOverScreen(bool value, int score, int highscore)
    {
        gameOverText.text = value ?  "YOU SURVIVED!" : "YOU DIED!";
        scoreText.text = $"Your Score: {score}";
        highScoreText.text =$"Highscore {highscore}";

    }

    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(scene.buildIndex);
    }
}

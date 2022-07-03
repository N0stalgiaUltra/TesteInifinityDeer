using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int highScore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            SetScore(50);
        else if (Input.GetKeyDown(KeyCode.L))
            SaveScore();

    }

    public void SetScore(int scoreEnemy) 
    {
        this.score += scoreEnemy;
    }

    public void SaveScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        PlayerPrefs.Save();
    }

    public int Score { get => score; }
}

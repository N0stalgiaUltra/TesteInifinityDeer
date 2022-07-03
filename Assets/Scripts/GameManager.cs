using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private HordeManager hordeManager;
    [SerializeField] private HudManager hudManager;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerCam playerCam;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        SpawnPlayer();
        hordeManager.StartRound();
    }

    public void SpawnPlayer()
    {
        GameObject p1 = PhotonNetwork.Instantiate(player.name, this.transform.position, Quaternion.identity);
        p1.SetActive(true);
        PlayerFinder.instance.AddPlayer(p1);
        playerCam.SetCamera(player.transform);
    }

    public void GameOver(bool victory)
    {
        scoreManager.SaveScore();
        Time.timeScale = 0f;
        gameOverScreen.gameObject.SetActive(true);
        gameOverScreen.SetGameOverScreen(victory, scoreManager.Score, scoreManager.Highscore);
    }
}

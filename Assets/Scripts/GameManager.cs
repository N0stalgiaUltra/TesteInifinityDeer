using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private HordeManager hordeManager;
    [SerializeField] private HudManager hudManager;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerCam playerCam;

    [SerializeField] private Button startGameBtn;
    //[SerializeField] private CinemachineVirtualCamera cam;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }
    private void Start()
    {
        Time.timeScale = 0;
        startGameBtn.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        startGameBtn.gameObject.SetActive(false);
        SpawnPlayer();
        hordeManager.StartRound();
    }

    public void SpawnPlayer()
    {
        GameObject p1 = PhotonNetwork.Instantiate(player.name, this.transform.position, Quaternion.identity);
        p1.SetActive(true);
        PlayerFinder.instance.AddPlayer(p1);
        playerCam.SetCamera(p1.transform);
    }

    public void GameOver(bool victory)
    {
        scoreManager.SaveScore();
        Time.timeScale = 0f;
        gameOverScreen.gameObject.SetActive(true);
        gameOverScreen.SetGameOverScreen(victory, scoreManager.Score, scoreManager.Highscore);
    }
}

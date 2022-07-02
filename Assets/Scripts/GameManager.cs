using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private HordeManager hordeManager;
    [SerializeField] private HudManager hudManager;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }
    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        //hudManager.StartUi();
        hordeManager.StartRound();
    }

    public void GameOver(bool victory)
    {
        if (victory)
            print("Fim de Jogo");
        else
            print("PERDEU1");
    }
}

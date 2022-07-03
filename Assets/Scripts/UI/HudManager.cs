using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudManager : MonoBehaviour
{
    [SerializeField] private HordeManager hordeManager;
    
    [Header("TextMesh References")]
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI hordeText;
    [SerializeField] private TextMeshProUGUI enemiesCountText;
    [SerializeField] private TextMeshProUGUI playerScore;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetUI();
    }

    public void SetUI()
    {
        
        playerName.text = "Player"; //implementar com o playfab
        playerScore.text = $"Score: {0}"; //implementar com o player score
        hordeText.text = $"Horde: {hordeManager.actualRound}/{hordeManager.RoundCount}";
        enemiesCountText.text = $"Enemies: {hordeManager.KillCount}/{hordeManager.EnemiesPerRound(hordeManager.actualRound-1)}";
    }
}

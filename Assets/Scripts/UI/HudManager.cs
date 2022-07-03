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
        
    }

    public void StartUi()
    {
        playerScore.text = $"{0}";
    }
}

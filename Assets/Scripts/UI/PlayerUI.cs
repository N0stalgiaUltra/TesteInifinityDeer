using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private TextMeshProUGUI reloadingText;
  

    void Start()
    {
        healthBar.fillAmount = playerHealth.HealthPlayer / 100;
        playerHealth.healthChanged += HealthChanged;
        reloadingText.enabled = false;

    }

    private void Update()
    {
        reloadingText.enabled = GunLogic.reloading;
    }

    void HealthChanged()
    {
        healthBar.fillAmount = (float)playerHealth.HealthPlayer / 100;
    }
}

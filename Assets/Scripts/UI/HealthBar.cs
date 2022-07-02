using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private PlayerHealth playerHealth;
  
    void Start()
    {
        healthBar.fillAmount = playerHealth.HealthPlayer / 100;
        playerHealth.healthChanged += HealthChanged;
    }

    void HealthChanged()
    {
        healthBar.fillAmount = (float)playerHealth.HealthPlayer / 100;
    }
}

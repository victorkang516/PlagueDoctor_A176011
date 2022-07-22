using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUIHandler : MonoBehaviour
{
    private Image healthBarUI;
    private Text healthPointText;

    float currentHealth;
    float maxHealth;
    PlayerStats playerStats;

    void Awake()
    {
        healthBarUI = GetComponent<Image>();

        healthPointText = GameObject.Find("HealthPointText").GetComponent<Text>();

        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    private void Start()
    {
        UpdateCurrentHealth();
    }

    public void UpdateCurrentHealth ()
    {
        // Health Bar
        currentHealth = playerStats.currentHealth;
        maxHealth = playerStats.maxHealth;

        healthBarUI.fillAmount = currentHealth / maxHealth;

        // Health Point Text

        healthPointText.text = currentHealth + "/" + maxHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPUIHandler : MonoBehaviour
{
    private Image healthBarUI;

    float currentHealth;
    float maxHealth;

    void Awake()
    {
        healthBarUI = GetComponent<Image>();
    }

    public void UpdateCurrentHealth(float cHealth, float mHealth)
    {
        // Health Bar
        currentHealth = cHealth;
        maxHealth = mHealth;

        healthBarUI.fillAmount = currentHealth / maxHealth;
    }
}

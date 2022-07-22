using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100f;

    public ParticleSystem healEffect;

    private HealthBarUIHandler healthBarUIHandler;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        healthBarUIHandler = GameObject.Find("HealthBarUI").GetComponent<HealthBarUIHandler>();
    }

    public void GetHurt (float receivedDmg)
    {
        currentHealth -= receivedDmg;

        CheckIfNoMoreHealth();

        healthBarUIHandler.UpdateCurrentHealth();
    }

    public void GetHeal(float receivedHeal)
    {
        Instantiate(healEffect, transform.position + new Vector3(0, 1f, 0), transform.rotation);

        maxHealth += receivedHeal;
        currentHealth += receivedHeal;

        CheckIfHealthAlreadyFull();

        healthBarUIHandler.UpdateCurrentHealth();
    }

    private void CheckIfHealthAlreadyFull ()
    {
        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
    }

    public void CheckIfNoMoreHealth()
    {
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            gameManager.RespawnPlayerAtCheckpoint();
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;

        healthBarUIHandler.UpdateCurrentHealth();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    GameManager gameManager;

    private EnemyHPUIHandler enemyHPUIHandler;

    public ParticleSystem deathEffect;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        enemyHPUIHandler = transform.Find("Canvas").Find("HPUI").GetComponent<EnemyHPUIHandler>();

        currentHealth = maxHealth;

        enemyHPUIHandler.UpdateCurrentHealth(currentHealth, maxHealth);
    }

    public void GetHurt(float receivedDmg)
    {
        currentHealth -= receivedDmg;
        CheckIfNoMoreHealth();

        enemyHPUIHandler.UpdateCurrentHealth(currentHealth, maxHealth);
    }

    public void CheckIfNoMoreHealth ()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position + new Vector3(0, 1f, 0), transform.rotation);
            Destroy(gameObject);
            gameManager.OpenFinalGate();
        }
    }
}

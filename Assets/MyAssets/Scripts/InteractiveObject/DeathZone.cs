using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    GameManager gameManager;
    PlayerStats playerStats;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerStats.ResetHealth();
            gameManager.RespawnPlayerAtCheckpoint();
        }
    }
}

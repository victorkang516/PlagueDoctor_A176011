using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoulderArea : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boulder"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            gameManager.SpawnBoulder();
        }
    }
}

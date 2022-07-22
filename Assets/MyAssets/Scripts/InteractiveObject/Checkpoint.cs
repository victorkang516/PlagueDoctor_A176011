using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameManager gameManager;

    private GameObject statIncreaseUI;

    private bool haveEntered = false;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        statIncreaseUI = GameObject.Find("StatsIncreaseUI");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (haveEntered == false)
        {
            statIncreaseUI.GetComponent<StatsIncreaseUI>().Show("Checkpoint Saved");
            gameManager.SaveCurrentCheckpoint(gameObject);
            haveEntered = true;
        }
    }
}

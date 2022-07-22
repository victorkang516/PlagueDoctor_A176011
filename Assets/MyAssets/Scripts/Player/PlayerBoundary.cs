using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBoundary : MonoBehaviour
{
    public Vector3 finalSpawnPoint = new Vector3(-79f, 41.2f, -220f);
    public Vector3 caveSpawnPoint = new Vector3(1f, 41.2f, -200f);
    public Vector3 redwoodForestSpawnPoint = new Vector3(20f, 38f, -100f);
    public Vector3 villageSpawnPoint = new Vector3(3f, 24.2f, -11f);
    public Vector3 startSpawnPoint = new Vector3(-43f, 21f, 42f);

    private Button startButton;
    private Button villageButton;
    private Button redForestButton;
    private Button caveEntranceButton;
    private Button caveFinalButton;

    private void Awake()
    {
        startButton = GameObject.Find("StartButton").GetComponent<Button>();
        villageButton = GameObject.Find("VillageButton").GetComponent<Button>();
        redForestButton = GameObject.Find("RedForestButton").GetComponent<Button>();
        caveEntranceButton = GameObject.Find("CaveEntranceButton").GetComponent<Button>();
        caveFinalButton = GameObject.Find("CaveFinalButton").GetComponent<Button>();

        startButton.onClick.AddListener(() => TeleportTo(startSpawnPoint));
        villageButton.onClick.AddListener(() => TeleportTo(villageSpawnPoint));
        redForestButton.onClick.AddListener(() => TeleportTo(redwoodForestSpawnPoint));
        caveEntranceButton.onClick.AddListener(() => TeleportTo(caveSpawnPoint));
        caveFinalButton.onClick.AddListener(() => TeleportTo(finalSpawnPoint));
    }

    private void Start()
    {
        
    }

    void TeleportTo(Vector3 spawnPoint)
    {
        transform.position = spawnPoint;
    }

    void Update()
    {
        //if (transform.position.x < -45 && transform.position.y < 41.2 && transform.position.z < -100)
        //{

        //}
        //else if (transform.position.x < -90 && transform.position.y > 41.2 && transform.position.z < -190)
        //{
        //    TeleportTo(finalSpawnPoint);
        //}
        //else if (transform.position.y < 35 && transform.position.z < -200)
        //{
        //    TeleportTo(caveSpawnPoint);
        //}
        //else if (transform.position.y < 30 && transform.position.z < -70)
        //{
        //    TeleportTo(redwoodForestSpawnPoint);
        //}
        //else if (transform.position.y < 20 && transform.position.z < -10)
        //{
        //    TeleportTo(villageSpawnPoint);
        //}
        //else if (transform.position.y < 10 && transform.position.z < 50)
        //{
        //    TeleportTo(startSpawnPoint);
        //}
    }
}

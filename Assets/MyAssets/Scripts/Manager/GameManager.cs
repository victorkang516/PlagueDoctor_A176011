using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Player Checkpoints
    GameObject player;

    private GameObject currentCheckpoint;

    // Game Obstacles

    GameObject caveDoor1Left;
    GameObject caveDoor1Right;

    GameObject caveDoor2Left;
    GameObject caveDoor2Right;

    public GameObject skeletonPrefab;
    public GameObject boulderPrefab;

    private GameObject skeletonSpawnPoint1;
    private GameObject skeletonSpawnPoint2;
    private GameObject boulderSpawnPoint;
    private GameObject trapDoor;
    private GameObject finalGate;

    // Game UI
    private GameObject missionUI;

    void Start()
    {
        // Player Checkpoints

        player = GameObject.Find("Player");

        caveDoor1Left = GameObject.Find("CaveDoor1Left");
        caveDoor1Right = GameObject.Find("CaveDoor1Right");

        caveDoor2Left = GameObject.Find("CaveDoor2Left");
        caveDoor2Right = GameObject.Find("CaveDoor2Right");

        skeletonSpawnPoint1 = GameObject.Find("SkeletonSpawnPoint1");
        skeletonSpawnPoint2 = GameObject.Find("SkeletonSpawnPoint2");

        boulderSpawnPoint = GameObject.Find("BoulderSpawnPoint");
        trapDoor = GameObject.Find("TrapDoor");

        finalGate = GameObject.Find("FinalGate");

        missionUI = GameObject.Find("MissionUI");
    }

    public void SaveCurrentCheckpoint (GameObject checkpoint)
    {
        currentCheckpoint = checkpoint;

        if (checkpoint.name == "Checkpoint0")
        {
            missionUI.GetComponent<MissionUI>().Show("Find Miranda Village");
        }
        else if (checkpoint.name == "Checkpoint1")
        {
            missionUI.GetComponent<MissionUI>().Show("Pass through Redwood Forest");
        }
        else if (checkpoint.name == "Checkpoint2")
        {
            missionUI.GetComponent<MissionUI>().Show("Get into Dungeon");
        }
        else if (checkpoint.name == "Checkpoint3")
        {
            missionUI.GetComponent<MissionUI>().Show("Find way to the Elixir");
        }
        else if (checkpoint.name == "Checkpoint4")
        {
            missionUI.GetComponent<MissionUI>().Show("Defeat Giant Beetle");
        }
    }

    public void RespawnPlayerAtCheckpoint ()
    {
        player.transform.position = currentCheckpoint.transform.position + new Vector3(0, 0, 2f);
    }


    void Update()
    {
        
    }

    public void OpenFirstDoor()
    {
        caveDoor1Left.GetComponent<MoveWall>().direction = -1;
        caveDoor1Right.GetComponent<MoveWall>().direction = 1;

        caveDoor1Left.GetComponent<MoveWall>().Move();
        caveDoor1Right.GetComponent<MoveWall>().Move();
    }

    public void CloseFirstDoor()
    {
        caveDoor1Left.GetComponent<MoveWall>().direction = 1;
        caveDoor1Right.GetComponent<MoveWall>().direction = -1;

        caveDoor1Left.GetComponent<MoveWall>().Move();
        caveDoor1Right.GetComponent<MoveWall>().Move();

        GameObject skeleton1 = Instantiate(skeletonPrefab, skeletonSpawnPoint1.transform.position, transform.rotation);
        GameObject skeleton2 = Instantiate(skeletonPrefab, skeletonSpawnPoint1.transform.position, transform.rotation);
        GameObject skeleton3 = Instantiate(skeletonPrefab, skeletonSpawnPoint1.transform.position, transform.rotation);
        GameObject skeleton4 = Instantiate(skeletonPrefab, skeletonSpawnPoint2.transform.position, transform.rotation);
        GameObject skeleton5 = Instantiate(skeletonPrefab, skeletonSpawnPoint2.transform.position, transform.rotation);
        GameObject skeleton6 = Instantiate(skeletonPrefab, skeletonSpawnPoint2.transform.position, transform.rotation);
    }

    public void OpenSecondDoor()
    {
        caveDoor2Left.GetComponent<MoveWall>().direction = -1;
        caveDoor2Right.GetComponent<MoveWall>().direction = 1;

        caveDoor2Left.GetComponent<MoveWall>().Move();
        caveDoor2Right.GetComponent<MoveWall>().Move();
    }

    public void SpawnBoulder ()
    {
        Instantiate(boulderPrefab, boulderSpawnPoint.transform.position, boulderPrefab.transform.rotation);
    }

    public void OpenTrapDoor()
    {
        trapDoor.transform.Translate(new Vector3(0, 0, 2f));
        trapDoor.transform.Rotate(90f, 0, 0);
    }

    public void OpenFinalGate()
    {
        finalGate.GetComponent<MoveWall>().Move();
        missionUI.GetComponent<MissionUI>().Show("Where my Elixir?");
    }
}

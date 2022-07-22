using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum turnDirection
{
    x,
    y,
    z
}

public class ObjectInteractionAnim : MonoBehaviour
{
    public float turnDegree;
    public turnDirection myTurnDirection;

    private float turnRadian;

    private GameObject turnablePart;
    private bool isPlayingAnim = false;

    void Start()
    {
        turnablePart = transform.GetChild(1).gameObject;

        turnRadian = (turnDegree / 180) * Mathf.PI;
    }

    public void PlayAnimation ()
    {
        GetComponent<AudioSource>().Play();
        isPlayingAnim = true;
    }

    private void Update()
    {

        if (isPlayingAnim)
        {
            if (myTurnDirection == turnDirection.x)
                turnablePart.transform.Rotate(new Vector3(-100f, 0, 0) * Time.deltaTime);
            else if (myTurnDirection == turnDirection.y)
                turnablePart.transform.Rotate(new Vector3(0, 90f, 0) * Time.deltaTime);
        }

        if (myTurnDirection == turnDirection.x)
        {
            if (turnablePart.transform.localRotation.x <= -turnRadian)
                isPlayingAnim = false;
        } 
        else if (myTurnDirection == turnDirection.y)
        {
            if (turnablePart.transform.localRotation.y <= -turnRadian)
                isPlayingAnim = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float moveXPositionBy;
    public float moveYPositionBy;
    public float moveZPositionBy;
    public float movementDuration;

    private bool directionFlag = true;

    void Start()
    {

        InvokeRepeating("ControlPlatformMovement", 0f, movementDuration);

        
    }

    void ControlPlatformMovement ()
    {
        directionFlag = !directionFlag;
    }

    void Update()
    {
        if (directionFlag)
        {
            transform.Translate(new Vector3(0.01f, 0, 0));
        }
        else
        {
            transform.Translate(new Vector3(-0.01f, 0, 0));
        }
    }
}

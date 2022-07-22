using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    bool isMoving = false;
    public float direction;

    public void Move ()
    {
        GetComponent<AudioSource>().Play();
        isMoving = true;
        StartCoroutine(WaitForAWhile());
    }

    IEnumerator WaitForAWhile()
    {
        yield return new WaitForSeconds(3.0f);
        isMoving = false;
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(new Vector3(0.01f * direction, 0, 0));
        }
    }
}

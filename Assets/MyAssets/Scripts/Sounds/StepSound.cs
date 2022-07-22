using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
    }
}

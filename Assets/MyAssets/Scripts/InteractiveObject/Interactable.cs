using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInteractable = true;

    public void PlayThankYou()
    {
        GetComponent<AudioSource>().Play();
    }
}

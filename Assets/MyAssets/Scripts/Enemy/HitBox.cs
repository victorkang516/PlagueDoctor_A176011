using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBox : MonoBehaviour
{
    public float hitDamage = 2;

    public ParticleSystem hitEffect;

    private void Start()
    {
        //
    }

    public void PlaySound()
    {
        if (GetComponent<AudioSource>() != null)
            GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<PlayerStats>().GetHurt(hitDamage);
            Instantiate(hitEffect, other.transform.position + new Vector3(0, 1f, 0), other.transform.rotation);
        }
    }
}

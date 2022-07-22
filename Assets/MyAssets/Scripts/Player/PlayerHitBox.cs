using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHitBox : MonoBehaviour
{
    public float hitDamage = 2;

    private Text dmgText;

    public ParticleSystem hitEffect;
    public ParticleSystem statsIncreaseEffect;

    void Awake()
    {
        dmgText = GameObject.Find("DmgText").GetComponent<Text>();
    }

    private void Start()
    {
        dmgText.text = hitDamage.ToString();
    }

    public void IncreaseHitDamage ()
    {
        hitDamage += 1;
        dmgText.text = hitDamage.ToString();
        Instantiate(statsIncreaseEffect, transform.parent.position + new Vector3(0, 1f, 0), transform.parent.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStats>().GetHurt(hitDamage);
            Instantiate(hitEffect, other.transform.position + new Vector3(0, 1f, 0), other.transform.rotation);
        }
        else if (other.CompareTag("Boss"))
        {
            other.GetComponent<BossStats>().GetHurt(hitDamage);
            Instantiate(hitEffect, other.transform.position + new Vector3(0, 1f, 0), other.transform.rotation);
        }
    }
}

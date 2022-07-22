using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    GameObject player;
    GameObject hitBox;
    GameObject hitBox2;
    GameObject hitBox3;

    public ParticleSystem smashEffect;
    public ParticleSystem spellEffect;

    Animator animator;
    float speed = 1.5f;

    float attackTimer = 0;
    float attackCooldownTime = 4.0f;

    bool isAttacking = false;

    int attackSequence = 0;

    private void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();

        hitBox = transform.GetChild(0).gameObject;
        hitBox.GetComponent<SphereCollider>().enabled = false;

        hitBox2 = transform.GetChild(1).gameObject;
        hitBox2.GetComponent<SphereCollider>().enabled = false;

        hitBox3 = transform.GetChild(2).gameObject;
        hitBox3.GetComponent<SphereCollider>().enabled = false;
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;

        if (Vector3.Distance(transform.position, player.transform.position) > 15.0f)
            return;

        transform.LookAt(player.transform, Vector3.up);

        if (isAttacking == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            animator.SetBool("Walk Forward", true);
        }

        if (Vector3.Distance(transform.position, player.transform.position) < 4.0f)
        {
            if (attackTimer > attackCooldownTime)
            {
                Attack();
                attackTimer = 0;
                animator.SetBool("Walk Forward", false);
            }

        }
    }

    public void Attack()
    {

        if (attackSequence < 2)
        {
            StartCoroutine(StabAttack());
            attackSequence += 1;
        }
        else if (attackSequence == 2)
        {
            StartCoroutine(SmashAttack());
            attackSequence += 1;
        }
        else
        {
            StartCoroutine(CastSpell());
            attackSequence = 0;
        }
    }

    IEnumerator StabAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.5f);

        animator.Play("Stab Attack", 0, 0.0f);
        hitBox.GetComponent<HitBox>().PlaySound();
        yield return new WaitForSeconds(0.4f);

        hitBox.GetComponent<SphereCollider>().enabled = true;
        yield return new WaitForSeconds(0.5f);

        hitBox.GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(2.0f);

        isAttacking = false;

        StopAllCoroutines();
    }

    IEnumerator SmashAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.5f);

        animator.Play("Smash Attack", 0, 0.0f);
        yield return new WaitForSeconds(0.8f);

        hitBox2.GetComponent<HitBox>().PlaySound();
        Instantiate(smashEffect, transform.position + new Vector3(0, 0, 0), transform.rotation);

        hitBox2.GetComponent<SphereCollider>().enabled = true;
        yield return new WaitForSeconds(0.5f);

        hitBox2.GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(2.0f);

        isAttacking = false;

        StopAllCoroutines();
    }

    IEnumerator CastSpell()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.5f);

        animator.Play("Cast Spell", 0, 0.0f);
        yield return new WaitForSeconds(1f);

        hitBox3.GetComponent<HitBox>().PlaySound();
        Instantiate(spellEffect, transform.position + new Vector3(0, 1.5f, 0), spellEffect.transform.rotation);

        hitBox3.GetComponent<SphereCollider>().enabled = true;
        yield return new WaitForSeconds(0.5f);

        hitBox3.GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(2.0f);

        isAttacking = false;

        StopAllCoroutines();
    }
}

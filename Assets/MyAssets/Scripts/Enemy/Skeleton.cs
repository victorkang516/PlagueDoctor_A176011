using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    GameObject player;
    GameObject hitBox;

    Animator animator;
    float speed = 1.5f;

    float attackTimer = 0;
    float attackCooldownTime = 4.0f;

    bool isAttacking = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        hitBox = transform.GetChild(2).gameObject;
        hitBox.SetActive(false);
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
            animator.SetFloat("Speed", speed);
        }

        if (Vector3.Distance(transform.position, player.transform.position) < 2.0f)
        {
            if (attackTimer > attackCooldownTime)
            {
                Attack();
                attackTimer = 0;
            }

        }
    }

    public void Attack ()
    {
        StartCoroutine(Attacking());
    }

    IEnumerator Attacking()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.5f);

        animator.Play("SkeletonAttack", 0, 0.0f);
        yield return new WaitForSeconds(0.4f);

        GetComponent<AudioSource>().Play();
        hitBox.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        hitBox.SetActive(false);
        yield return new WaitForSeconds(2.0f);

        isAttacking = false;

        StopAllCoroutines();
    }

}

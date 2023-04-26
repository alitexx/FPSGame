using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyManager : MonoBehaviour
{
    public float damage = 10;

    private GameObject player;
    private NavMeshAgent NMA;
    private Animator enemyAnimator;
    public float health;
    public AudioSource bearGrowl;
    private manageRagdoll ragdollScript;
    private bool isAlive = true;

    public void Hit(float damage)
    {
        health -= damage;
        if (health <= 0 && isAlive == true)
        {
            // make a RAGDOLL EFFECT!!!!!!
            isAlive = false;
            globalVariables.bearsKilled++;
            enemyAnimator.SetBool("Idle", false);
            enemyAnimator.SetBool("Run Forward", false);
            ragdollScript.enabled = true;
            NMA.enabled = false;
            gameObject.GetComponent<enemyManager>().enabled = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        NMA = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        ragdollScript = GetComponent<manageRagdoll>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 20)
        {
            NMA.destination = player.transform.position;
            if (Vector3.Distance(player.transform.position, transform.position) < 3)
            {
                NMA.destination = gameObject.transform.position;
            }
            if (Vector3.Distance(player.transform.position, transform.position) < 5)
            {
                bearGrowl.Play();
                enemyAnimator.SetTrigger("Attack5");
                enemyAnimator.SetBool("Idle", false);
                enemyAnimator.SetBool("Run Forward", false);
                StartCoroutine(stillInRange());
                return;
            }
            if (NMA.velocity.magnitude > 1)
            {
                enemyAnimator.SetBool("Run Forward", true);
                enemyAnimator.SetBool("Idle", false);
            }
            else
            {
                enemyAnimator.SetBool("Idle", true);
                enemyAnimator.SetBool("Run Forward", false);
            }
        }
        else
        {
            enemyAnimator.SetBool("Idle", true);
            enemyAnimator.SetBool("Run Forward", false);
        }
    }

    IEnumerator stillInRange()
    {
        yield return new WaitForSeconds(.75f);
        if (Vector3.Distance(player.transform.position, transform.position) < 5)
        {
            StartCoroutine(player.GetComponent<PlayerManager>().damagePlayer());
        }
    }
}

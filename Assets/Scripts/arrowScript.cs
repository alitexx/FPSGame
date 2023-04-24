using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    public int damage;
    private AudioSource damageEnemy;

    private void Start()
    {
        damageEnemy = gameObject.GetComponent<AudioSource>();
        StartCoroutine(deleteSelf());
    }

    IEnumerator deleteSelf()
    {
        yield return new WaitForSeconds(7.5f);
        Destroy(gameObject);
    }


    void OnTriggerEnter(Collider col)
    {
        enemyManager enemy_manager = col.transform.GetComponent<enemyManager>();
        if (enemy_manager != null)
        {
            damageEnemy.Play();
            enemy_manager.Hit(damage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        explosionScript explosion = collision.transform.GetComponent<explosionScript>();
        if (explosion != null)
        {
            explosion.ExplosionDamage(5f);
            Destroy(gameObject);
        }
        
    }
}

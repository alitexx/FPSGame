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
        Debug.Log(col.gameObject.name);
        enemyManager enemy_manager = col.transform.GetComponent<enemyManager>();
        if (enemy_manager != null)
        {
            damageEnemy.Play();
            enemy_manager.Hit(damage);
        }
        Destroy(gameObject);
    }
}

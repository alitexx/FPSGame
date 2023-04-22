using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    public int damage;


    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        enemyManager enemy_manager = col.transform.GetComponent<enemyManager>();
        if (enemy_manager != null)
        {
            enemy_manager.Hit(damage);
        }
        Destroy(gameObject);
    }
}

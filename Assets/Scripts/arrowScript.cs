using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter(Collider other)
    {
        enemyManager enemy_manager = other.transform.GetComponent<enemyManager>();
        if (enemy_manager != null)
        {
            enemy_manager.Hit(damage);
        }
        Destroy(gameObject);
    }
}

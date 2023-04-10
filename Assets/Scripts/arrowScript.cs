using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter(Collider other)
    {
        // do something
        Debug.Log("I am doing something");
    }
}

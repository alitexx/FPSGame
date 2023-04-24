using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageRagdoll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countdown());
    }

    public IEnumerator countdown()
    {
        gameObject.GetComponent<Animator>().SetBool("Death", true);
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem partSys;
    public AudioSource explosion;

    public void ExplosionDamage(float radius)
    {
        StartCoroutine(countdown());
        partSys.Play();
        int maxColliders = 10;
        Collider[] hitColliders = new Collider[maxColliders];
        int numColliders = Physics.OverlapSphereNonAlloc(gameObject.transform.position, radius, hitColliders);
        for (int i = 0; i < numColliders; i++)
        {
            Debug.Log(hitColliders[i].gameObject.name);
            if (hitColliders[i].gameObject.tag == "Player")
            {
                hitColliders[i].gameObject.GetComponent<PlayerManager>().Hit(10f);
            } else if (hitColliders[i].gameObject.tag == "Enemy")
            {
                hitColliders[i].gameObject.GetComponent<enemyManager>().Hit(50f);
            }
        }
    }

    void Start()
    {
        partSys = gameObject.GetComponent<ParticleSystem>();
        partSys.Stop();
    }

    public IEnumerator countdown()
    {
        explosion.Play();
        yield return new WaitForSeconds(.75f);
        Destroy(gameObject);
    }
}

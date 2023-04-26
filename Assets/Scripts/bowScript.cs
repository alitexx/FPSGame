using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowScript : MonoBehaviour
{
    float _charge;
    public float chargeMax;
    public float chargeRate;

    private Animator _animator;

    public KeyCode fireButton;
    public Transform spawn;
    public Rigidbody arrowObj;

    private float cooldownTime = 1.0f;
    private bool canShoot = true;
    public AudioSource shootArrow;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (globalVariables.canPause == true)
        {
            if (Input.GetKey(fireButton) && (_charge < chargeMax))
            {
                _charge += Time.deltaTime * chargeRate;
                _animator.SetBool("isCharging", true);

            }
            if (Input.GetKeyUp(fireButton) && canShoot == true)
            {
                _animator.SetBool("isCharging", false);
                _animator.SetTrigger("Shoot");
                Rigidbody arrow = Instantiate(arrowObj, spawn.position, Quaternion.identity) as Rigidbody;
                arrow.gameObject.transform.rotation = gameObject.transform.rotation;

                if (_charge > chargeMax)
                {
                    _charge = chargeMax;
                }
                shootArrow.Play();
                arrow.AddForce(spawn.forward * _charge, ForceMode.Impulse);
                _charge = 0;
                StartCoroutine(cooldown());
            }
        }
    }

    IEnumerator cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }

}

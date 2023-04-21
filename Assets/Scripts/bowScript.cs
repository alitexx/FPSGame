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

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(fireButton) && (_charge < chargeMax))
        {
            _charge += Time.deltaTime * chargeRate;
            _animator.SetBool("isCharging", true);

        } 
        if (Input.GetKeyUp(fireButton))
        {
            _animator.SetBool("isCharging", false);
            _animator.SetTrigger("Shoot");
            Rigidbody arrow = Instantiate(arrowObj, spawn.position, Quaternion.identity) as Rigidbody;
            arrow.gameObject.transform.rotation = gameObject.transform.rotation;
            
            if (_charge > chargeMax)
            {
                _charge = chargeMax;
            }
            arrow.AddForce(spawn.forward * _charge, ForceMode.Impulse);
            _charge = 0;
        }
    }

}

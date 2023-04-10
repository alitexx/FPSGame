using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowScript : MonoBehaviour
{
    float _charge;
    public float chargeMax;
    public float chargeRate;

    public KeyCode fireButton;
    public Transform spawn;
    public Rigidbody arrowObj;

    private void Update()
    {
        if (Input.GetKey(fireButton) && (_charge < chargeMax))
        {
            _charge += Time.deltaTime * chargeRate;

        } 
        if (Input.GetKeyUp(fireButton))
        {
            Rigidbody arrow = Instantiate(arrowObj, spawn.position, Quaternion.identity) as Rigidbody;
            if (_charge > chargeMax)
            {
                _charge = chargeMax;
            }
            arrow.AddForce(spawn.forward * _charge, ForceMode.Impulse);
            _charge = 0;
        }
    }

}

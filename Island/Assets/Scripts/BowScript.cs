using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    float charge;
    public float chargedMax;
    public float chargeRate;


    public KeyCode fireButton;

    public Transform spawn;
    public Rigidbody arrowObj;

    private void Update()
    {
        if(Input.GetKey(fireButton) && charge <chargedMax)
        {
            charge += Time.deltaTime * chargeRate;
            Debug.Log(charge.ToString());

        }

        if(Input.GetKeyUp(fireButton))
        {
            Rigidbody arrow = Instantiate(arrowObj, spawn.position, Quaternion.identity) as Rigidbody;
            arrow.AddForce(spawn.forward * charge, ForceMode.Impulse);
            charge = 0;
        }
    }

}

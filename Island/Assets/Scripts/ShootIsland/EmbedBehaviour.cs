using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmbedBehaviour : MonoBehaviour
{
    Rigidbody rigidB;
    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Embed();
        transform.parent = other.transform.parent;
    }

    void Embed()
    {
        GetComponent<Collider>().enabled = false;
        transform.GetComponent<ProjectileAddForce>().enabled = false;
        rigidB.velocity = Vector3.zero;
        rigidB.useGravity = false;
        rigidB.isKinematic = true;
    }
}

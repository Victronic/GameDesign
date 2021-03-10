using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    Collider coll;
    MeshRenderer myRend;

    public float health = 20f;
    private float startingHealth;
    public float resources = 10f;
    public float respawntime = 3f;


    // Start is called before the first frame update
    void Start()
    {

        coll = GetComponent<Collider>();
        myRend = GetComponent<MeshRenderer>();
        startingHealth = health;

    }

    public void HarvestResources(float amnt)
    {
        health -= amnt;
        if(health<=0)
        {
            StartCoroutine(WaitRespawn());

        }
    }

    IEnumerator WaitRespawn()
    {
        coll.enabled = false;
        myRend.enabled = false;
        print("Added" + resources.ToString() + "to player inventory");
        yield return new WaitForSeconds(respawntime);
        coll.enabled = true;
        myRend.enabled = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedObj : MonoBehaviour
{
    Collider coll;
    MeshRenderer myRend;

    // Start is called before the first frame update
    void Start()
    {

        coll = GetComponent<Collider>();
        myRend = GetComponent<MeshRenderer>();
    }

    public void HarvestResources()
    {
        coll.enabled = false;
        myRend.enabled = false;
        //StartCoroutine(WaitRespawn());   
    }

    //IEnumerator WaitRespawn()
    //{
    //    coll.enabled = false;
    //    myRend.enabled = false;
    //    yield return new WaitForSeconds(respawntime);
    //    coll.enabled = true;
    //    myRend.enabled = true;
    //}

}

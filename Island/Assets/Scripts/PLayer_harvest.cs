using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer_harvest : MonoBehaviour
{
    public Camera cam;
    public Transform hand;
    public float interactDist = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoInteraction();
    }

    private void DoInteraction()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit, interactDist))
        {
            if (hit.collider.tag == "Harvest")
            {
                if(Input.GetMouseButtonDown(0))
                {
                    Harvest currentHarvest = hit.collider.GetComponent<Harvest>();
                    currentHarvest.HarvestResources(10f);
                }
            }

        }
    }
}

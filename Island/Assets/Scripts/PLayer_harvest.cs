using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer_harvest : MonoBehaviour
{
    public Camera cam;
    public Transform hand;
    public float interactDist = 10f;
    public GameObject panel;
    public GameObject meniu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            meniu.SetActive(!meniu.activeSelf);
            if (meniu.activeSelf == true)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }


        if (Input.GetKeyDown(KeyCode.V))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    panel.SetActive(!panel.activeSelf);
                }
            }
        }
    }
}

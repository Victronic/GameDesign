using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTome : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        bool adevarat = false;
        if (Input.GetKeyDown(KeyCode.P))
        {
            adevarat = inventory.isTome();
            if (adevarat)
            {
                Debug.Log("bine");
            }
            else
                Debug.Log("nu");
        }


    }
}

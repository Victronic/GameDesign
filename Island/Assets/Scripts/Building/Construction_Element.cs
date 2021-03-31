using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction_Element : MonoBehaviour
{
    public int floor = 0;
    public int wall = 0;
    public int ceil = 0;

    public void raise_floor()
    {
        floor++;
    }
    public void raise_wall()
    {
        wall++;
    }
    public void raise_ceiling()
    {
        ceil++;
    }


}

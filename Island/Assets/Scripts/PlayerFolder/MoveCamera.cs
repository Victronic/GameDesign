using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform cameraPositon;

    void Update()
    {
        transform.position = cameraPositon.position;   
    }
}

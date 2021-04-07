using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public int health;

    public void Hit (int damage)
    {
        health -= damage;
        Debug.Log("ceva");
    }

    public void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

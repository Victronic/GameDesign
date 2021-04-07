using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider col)
    {

            if (col.GetComponent<EnemyStat>()){
                EnemyStat stats = col.GetComponent<EnemyStat>();
                stats.Hit(damage);
            }
    }
}

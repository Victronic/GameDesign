using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowReset : MonoBehaviour
{
    [SerializeField] GameObject shootObj;
    [SerializeField] GameObject scoreManagerObj;

    private void Start()
    {
        Shoot shoot = shootObj.GetComponent<Shoot>();
        shoot.numberOfArrows = 20;
    }
    private void Update()
    {
        ScoreManager scoreManager = scoreManagerObj.GetComponent<ScoreManager>();
        if (Input.GetKeyDown(KeyCode.T))
        {
            Shoot shoot = shootObj.GetComponent<Shoot>();
            shoot.numberOfArrows = 20;
            scoreManager.score = 0;
        }
    }
}

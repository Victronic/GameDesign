using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public static ScoreManager instance;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject door1;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Points: " + score.ToString();
        if (score > 300)
        {
            Destroy(door1);
        }
    }
}

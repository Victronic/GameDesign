using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointTraker : MonoBehaviour
{
    [SerializeField] GameObject impactPrefab;
    public int value = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.instance.score += value;
        GameObject _canvas = Instantiate(impactPrefab, other.transform.position, other.transform.rotation);
        _canvas.GetComponentInChildren<RectTransform>().position = Camera.main.WorldToScreenPoint(other.transform.position);
        _canvas.GetComponentInChildren<Text>().text = value.ToString();
        Destroy(_canvas, 2);
    }
}

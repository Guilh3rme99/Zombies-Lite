using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomText : MonoBehaviour
{
    private RoundController rc;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        rc = FindObjectOfType<RoundController>();
        text.text = "Round: 1\nScore: 0";    
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Round: " + rc.round + "\nScore: " + rc.score;            
    }
}

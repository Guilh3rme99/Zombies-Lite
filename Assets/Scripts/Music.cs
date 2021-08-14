using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DiamondPrefab;
    public static int collected;
    private bool played;
    
    void Start()
    {
        played = false;
        collected = 0;
        Vector3 position = new Vector3(Random.Range(-9f,9f),Random.Range(-9f,9f), 0);
        Instantiate(DiamondPrefab, position, Quaternion.Euler(0,0,0));

        position = new Vector3(Random.Range(-9f,9f), Random.Range(-9f,9f), 0);
        Instantiate(DiamondPrefab, position, Quaternion.Euler(0,0,0));

        position = new Vector3(Random.Range(-9f,9f),  Random.Range(-9f,9f), 0);
        Instantiate(DiamondPrefab, position, Quaternion.Euler(0,0,0));

    }

    // Update is called once per frame
    void Update()
    {
        if(collected==3 && played == false){
            gameObject.GetComponent<AudioSource>().Play();
            played = true;
        }    
    }
}

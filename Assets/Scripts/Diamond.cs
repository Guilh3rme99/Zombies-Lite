using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    // Start is called before the first frame update
    private bool collected;
    void Start()
    {
        collected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Soldier_pistol" && collected == false){
            Music.collected ++;
            collected = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            AudioSource sound = gameObject.GetComponent<AudioSource>();
            sound.Play();
            Destroy(gameObject, sound.clip.length);    
        }    
    }
}

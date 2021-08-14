using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;
    private bool collected;
    void Start()
    {     
        timer = 0;
        collected = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=60){
            Destroy(gameObject);    
        }    
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.name == "Soldier_pistol" && collected == false){
            collected = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            AudioSource sound = gameObject.GetComponent<AudioSource>();
            sound.Play();
            Destroy(gameObject, sound.clip.length);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Zombie");
            for(int i=0; i< enemies. Length; i++){
                Destroy(enemies[i]);
                Zombie.kills++;
                Zombie.totalKills++;
            }
        }
        
    }
}

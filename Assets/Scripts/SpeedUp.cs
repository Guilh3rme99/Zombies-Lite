using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;
    private bool coletado;
    void Start()
    {
        timer = 0;
        coletado = false;        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=60){
            PlayerControler.speed = 1f;
            Destroy(gameObject);    
        }     
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Soldier_pistol" && coletado == false){
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Renderer>().enabled = false;
            timer = 0f;
            PlayerControler.speed = 2f;
            coletado = true;
        }
        
    }
}

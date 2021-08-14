using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    public static int bulletDamage = 10;
    

    void Update() {
        AudioSource audio = this.GetComponent<AudioSource>();
        if(!audio.isPlaying){
            Destroy(gameObject);
        }
    }
}

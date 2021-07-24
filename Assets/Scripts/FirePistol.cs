using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletVelocity;
    public float bulletDamage;
    public bool movement;
    public float fireRate;
    private float lastFired;
    private AudioSource sound;

    void Start(){
        movement = true;
        sound = bulletPrefab.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(movement == true){    
            if(Input.GetButton("Fire1")){
                if (Time.time - lastFired > 1 / fireRate){
                    lastFired = Time.time;
                    Shoot();
                }
            }
        }
    }

    void Shoot(){
        if(bulletPrefab!=null) sound.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletVelocity, ForceMode2D.Impulse);
    }

}

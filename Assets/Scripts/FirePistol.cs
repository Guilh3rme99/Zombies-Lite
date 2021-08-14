using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePointAK;
    public Transform firePointSG1;
    public Transform firePointSG2;
    public GameObject bulletPrefab;

    public float bulletVelocity;
    public float bulletDamage;
    public bool movement;
    public static float fireRate;
    private float lastFired;
    private AudioSource sound;

    void Start(){
        movement = true;
        sound = bulletPrefab.GetComponent<AudioSource>();
        bulletDamage = 10;
        bulletVelocity = 10;
        fireRate = 3;
    }

    void Update()
    {
        if(movement == true){    
            if(Input.GetButton("Fire1")){
                if (Time.time - lastFired > 1 / fireRate){
                    lastFired = Time.time;
                    if(PlayerControler.mode=="pistol"){
                        Shoot();
                    }else if(PlayerControler.mode=="ak"){
                        ShootAK();
                    }else{
                        Shoot12();
                    }
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

    void ShootAK(){
        if(bulletPrefab!=null) sound.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePointAK.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointAK.up * bulletVelocity, ForceMode2D.Impulse);
    }

    void Shoot12(){
        if(bulletPrefab!=null) sound.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePointAK.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointAK.up * bulletVelocity, ForceMode2D.Impulse);
        
        GameObject bullet1 = Instantiate(bulletPrefab, firePointSG1.position, firePointSG1.rotation);
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        rb1.AddForce(firePointSG1.up * bulletVelocity, ForceMode2D.Impulse);
        
        GameObject bullet2 = Instantiate(bulletPrefab, firePointSG2.position, firePointSG2.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePointSG2.up * bulletVelocity, ForceMode2D.Impulse);
    }


}

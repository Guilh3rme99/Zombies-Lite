using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private RoundController rc;
    public Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;
    public int life;
    public static float moveSpeed;
    public static int kills;
    public static int totalKills;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rc = FindObjectOfType<RoundController>();
        life = 60 + (rc.round - 1) * 5;
        moveSpeed = 0.2f;
        kills=0;
        totalKills=0;
    }
    
    void Update()
    {
        target = GameObject.FindWithTag("Player").transform;
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    void moveZombie(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void FixedUpdate(){
        moveZombie(movement);    
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            PlayerControler playerScript = other.gameObject.GetComponent<PlayerControler>();
            playerScript.hp -= 1;
        }

    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Pistol_Bullet(Clone)"){
            PistolBullet damage = other.gameObject.GetComponent<PistolBullet>();
            this.life -= damage.bulletDamage;
            rc.score += 10;
            if(this.life<=0){
                Destroy(gameObject);
                rc.score += 50;
                kills++;
                totalKills++;
            }
        }
    }

}

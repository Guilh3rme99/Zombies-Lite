using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Sprite ak;
    public Sprite shotgun;
    public bool movement;
    public static float speed;
    Rigidbody2D rb;
    public Camera cam;
    public int hp = 1;
    Vector2 mousePos;
    public static string mode;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = 1;
        movement = true;
        mode = "pistol";
        speed = 1f;
    }

    void Update(){
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if(hp==0){
            FindObjectOfType<RoundController>().EndGame();
        }
        if(mode=="ak"){
            this.GetComponent<SpriteRenderer>().sprite = ak;
        }else if(mode=="shotgun"){
            this.GetComponent<SpriteRenderer>().sprite = shotgun;
        }
    }

    private void FixedUpdate(){
        if(movement==true){
            /*if(Input.GetKey("w")){
                rb.velocity = Vector2.up * speed;
            }else if(Input.GetKey("s")){
                rb.velocity = Vector2.down * speed;
            }else if(Input.GetKey("d")){
                rb.velocity = Vector2.right * speed;
            }else if(Input.GetKey("a")){
                rb.velocity = Vector2.left * speed;    
            }else{
                rb.velocity = Vector2.zero;
            }*/

            var v2 = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            rb.velocity = speed * v2; 
        
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }
}

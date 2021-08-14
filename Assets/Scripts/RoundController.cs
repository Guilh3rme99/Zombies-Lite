using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    public GameOverScreen gameOver;
    public GameObject zombiePrefab;
    private Vector2 screenBounds;
    public int round = 1;
    public int numPerRound = 2;
    private int spawned = 0;
    public int initiate = 3;
    private bool gameEnded = false;
    public int score;
    public Button AKbutton;
    public Button SGButton;
    public Button PaPButton;

    
    // Start is called before the first frame update
    void Start()
    {
        round = 1;
        numPerRound = 2;
        initiate = 3;
        score = 0;
        AKbutton.interactable = false;
        SGButton.interactable = false;
        PaPButton.interactable = false;    
    }

    void spawnZombie(){
        for(int i=0; i<initiate + round*numPerRound; i++){
            GameObject p = GameObject.FindWithTag("Player");
            Vector3 position = new Vector3(p.transform.position.x + Random.Range(-8.8f,8.8f), p.transform.position.y + Random.Range(-8.8f,8.8f), 0);
            while((position - p.transform.position).magnitude < 2.5 || position.x < -8.9 || position.x > 8.9 || position.y < -8.9 || position.y > 8.9){
                position = new Vector3(p.transform.position.x + Random.Range(-8.8f,8.8f), p.transform.position.y + Random.Range(-8.8f,8.8f), 0);    
            }
            Instantiate(zombiePrefab,position, Quaternion.identity);
            spawned++;
        }
    }
    
    
    void Update()
    {
        if(initiate + round*numPerRound>spawned){
            spawnZombie();    
        }

        if(Zombie.kills== initiate + round*numPerRound){
            round++;
            spawned=0;
            Zombie.kills=0;
            if(Zombie.moveSpeed<0.8) Zombie.moveSpeed+=0.01f;
        }

        if(score>=2000){
            AKbutton.interactable = true;
            SGButton.interactable = true;
        }else{
            AKbutton.interactable = false;
            SGButton.interactable = false;       
        }
        
        if(score>=5000){
            PaPButton.interactable = true;
        }else{
            PaPButton.interactable = false;    
        }

    }

    public void EndGame(){
        if(gameEnded == false){
            gameEnded = true;
            FindObjectOfType<PlayerControler>().movement = false;
            FindObjectOfType<FirePistol>().movement = false;
            gameOver.Setup();    
        }
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void Exit(){
        Application.Quit();
    }

    public void AKB(){
        AKbutton.GetComponent<AudioSource>().Play();
        score -= 2000;
        FirePistol.fireRate = 8;
        PistolBullet.bulletDamage = 15;
        PlayerControler.mode = "ak";
    }
    
    public void ShotGunB(){
        AKbutton.GetComponent<AudioSource>().Play();
        score -= 2000;
        FirePistol.fireRate = 3;
        PistolBullet.bulletDamage = 20;
        PlayerControler.mode = "shotgun";
    }

    public void PackaPunch(){
        AKbutton.GetComponent<AudioSource>().Play();
        score -= 5000;
        PistolBullet.bulletDamage += 5;
    }


}

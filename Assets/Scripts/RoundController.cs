using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    // Start is called before the first frame update
    void Start()
    {
        round = 1;
        numPerRound = 2;
        initiate = 3;
        score = 0;    
    }

    void spawnZombie(){
        for(int i=0; i<initiate + round*numPerRound; i++){
            GameObject p = GameObject.FindWithTag("Player");
            Vector3 position = new Vector3(p.transform.position.x + Random.Range(-10f,10f), p.transform.position.y + Random.Range(-10f,10f), 0);
            while((position - p.transform.position).magnitude < 2.5){
                position = new Vector3(p.transform.position.x + Random.Range(-10f,10f), p.transform.position.y + Random.Range(-10f,10f), 0);    
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
            if(Zombie.moveSpeed<0.4) Zombie.moveSpeed+=0.01f;
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
}

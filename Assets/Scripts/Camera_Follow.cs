using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    private Transform player;

    // Update is called once per frame
    void FixedUpdate()
    {
        player = GameObject.FindWithTag("Player").transform;
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);    
    }
}

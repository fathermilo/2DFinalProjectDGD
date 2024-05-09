using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 3.0f;
    private Rigidbody2D enemyRb;
    private PlayerController playerControllerScript;
    


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        Destroy(gameObject, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        // follows the player at the same speed
        // normalized means that the vector keeps the same direction but its length is 1.0
        // which allows the enemy to try and keep up
        followPlayer();

       
    }

    void followPlayer()
    {
        Vector3 lookDirection = (playerControllerScript.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust speed as needed

    // Update is called once per frame
    void Update()
    {
        // Move the enemy horizontally (left or right) at a certain speed
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
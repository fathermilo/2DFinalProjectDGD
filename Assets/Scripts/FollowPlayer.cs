using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // public and private variables
    public GameObject player;
    private Vector3 offset = new Vector3(0, 0, -10);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {

        // follows the player when it moves
        transform.position = player.transform.position + offset;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsRotation : MonoBehaviour
{
    // public float rotationSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // makes the player's power indicator to spin
        transform.Rotate(0, 0, 1 * Time.deltaTime);
    }
}



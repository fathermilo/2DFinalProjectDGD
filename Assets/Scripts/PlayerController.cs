using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

     
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.left * horizontalInput * Time.deltaTime * speed);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.down * verticalInput * Time.deltaTime * speed);
    }
}




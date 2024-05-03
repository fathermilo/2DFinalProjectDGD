using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{

    public GameObject weapon_prefab;
    public GameObject[] barrel_hardpoints;
    public float shot_speed;
    int barrel_index = 0;
    public float turretRotationSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector2 mousePosition = Input.mousePosition;

        // Convert the turret's position to screen coordinates
        Vector2 turretPosition = Camera.main.WorldToScreenPoint(transform.position);

        // Calculate the direction from turret to mouse
        Vector3 direction = mousePosition - turretPosition;

        // Calculate the angle between the direction and the x-axis
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        // Create a rotation towards the calculated angle
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turretRotationSpeed * Time.deltaTime);


        if (Input.GetMouseButtonDown(0) && barrel_hardpoints != null)
        {
            GameObject bullet = (GameObject)Instantiate(weapon_prefab, barrel_hardpoints[barrel_index].transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * shot_speed);
            bullet.GetComponent<Shooting>().firing_ship = transform.parent.gameObject;
            barrel_index++; //This will cycle sequentially through the barrels in the barrel_hardpoints array

            if (barrel_index >= barrel_hardpoints.Length)
                barrel_index = 0;

        }
    }

}

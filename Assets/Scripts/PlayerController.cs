using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float powerupSpeedMultiplier = 2.0f; // Speed multiplier when the player has a power-up
    private float normalSpeed; // Store the normal speed

    public GameObject powerupIndicator;
    public bool hasPowerup = false;

    // Start is called before the first frame update
    void Start()
    {
        normalSpeed = speed; // Store the normal speed at the start
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<GameManager>().isGameActive)
            return;

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        // Check if the player has the power-up
        if (hasPowerup && Input.GetKey(KeyCode.LeftShift))
        {
            // Apply speed boost if the player has the power-up and is holding down the Shift key
            speed = normalSpeed * powerupSpeedMultiplier;
        }
        else
        {
            // Reset speed to normal if the player doesn't have the power-up or isn't holding down the Shift key
            speed = normalSpeed;
        }

        // Get horizontal and vertical input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the player
        transform.Translate(Vector3.left * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.down * verticalInput * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
        Debug.Log("Player has lost the powerup");
    }
}




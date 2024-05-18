using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public GameObject shoot_effect;
    public GameObject hit_effect;
    public GameObject firing_ship;
    public int pointValue;
    private GameManager gameManager;

    void Start()
    {
        GameObject muzzleFlash = Instantiate(shoot_effect, transform.position - new Vector3(0, 0, 5), Quaternion.identity);
        muzzleFlash.transform.parent = firing_ship.transform;
        Destroy(gameObject, 5f); // Bullet will despawn after 5 seconds
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(hit_effect, transform.position, Quaternion.identity);
            Destroy(col.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the bullet
        }

    }
}

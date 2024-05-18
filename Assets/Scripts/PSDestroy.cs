using UnityEngine;
using System.Collections;

public class PSDestroy : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        // Destroy the GameObject after the duration of the ParticleSystem
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

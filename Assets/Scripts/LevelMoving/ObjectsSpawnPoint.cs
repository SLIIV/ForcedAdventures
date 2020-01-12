using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawnPoint : MonoBehaviour
{
    private Vector3 startPos;
    private AudioSource source;
    void Awake()
    {
        source = GameObject.Find("Teleportator").GetComponent<AudioSource>();
        startPos = transform.position;
    }
    void OnTriggerEnter(Collider prop)
    {
        if (prop.CompareTag("LosePosition"))
        {
            transform.position = startPos;
        }
        if (prop.CompareTag("Teleportator"))
        {
            source.Play();
        }
    }
}

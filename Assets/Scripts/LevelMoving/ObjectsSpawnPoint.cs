using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawnPoint : MonoBehaviour
{
    private Vector3 startPos;
    private AudioSource source;
    void Awake()
    {
        try
        {
            source = GameObject.Find("Teleportator").GetComponent<AudioSource>();
        }
        catch (System.Exception)
        {
            Debug.Log("Внимание: источник звука не найден");
        }
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

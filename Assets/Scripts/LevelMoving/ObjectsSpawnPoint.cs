using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawnPoint : MonoBehaviour
{
    private Vector3 startPos;
    void Awake()
    {
        startPos = transform.position;
    }
    void OnTriggerEnter(Collider prop)
    {
        if (prop.CompareTag("LosePosition"))
        {
            transform.position = startPos;
        }
    }
}

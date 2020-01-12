using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 teleportDirection;
    void OnTriggerEnter(Collider prop)
    {
        if (!prop.CompareTag("Player") && !prop.CompareTag("Ground"))
            prop.gameObject.transform.position = teleportDirection;
    }
}

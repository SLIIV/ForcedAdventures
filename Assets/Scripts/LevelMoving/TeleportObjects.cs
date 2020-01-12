using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObjects : MonoBehaviour
{
    void OnTriggerEnter(Collider prop)
    {
        if (!prop.CompareTag("Player"))
        {
            Destroy(prop);
            transform.position = new Vector3(transform.position.x, transform.position.y - 3.5f, transform.position.z);
        }
    }
}

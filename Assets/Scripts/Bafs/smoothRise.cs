using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothRise : MonoBehaviour
{
    public float riseSpeed = 0.5f;
    void OnTriggerStay(Collider prop)
    {
        if (!prop.CompareTag("Ground"))
        {
            Rigidbody rb = prop.GetComponent<Rigidbody>();
            rb.useGravity = false; // if player in trigger collider, he does not have gravity and rises up
            prop.gameObject.transform.position += new Vector3(0, riseSpeed * Time.deltaTime, 0);
        }
    }
    void OnTriggerExit(Collider prop)
    {
        if (!prop.CompareTag("Ground"))
        {
            Rigidbody rb = prop.GetComponent<Rigidbody>();
            rb.useGravity = true; // if player exited trigger collider, he gains gravity
        }
    }
}

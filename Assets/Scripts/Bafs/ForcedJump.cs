using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedJump : MonoBehaviour
{
    public float jumpForce; // jump force
    void OnTriggerEnter(Collider prop)
    {
        if (prop.CompareTag("Player"))
        {
            Rigidbody rbProp = prop.GetComponent<Rigidbody>();
            rbProp.AddForce((Vector3.up * jumpForce * 1000) * Time.deltaTime);// push the ball up
        }
    }
}

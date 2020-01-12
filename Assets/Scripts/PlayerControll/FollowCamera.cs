using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform gameobjectPosition; // this gameObject pos
    public Transform centerPosition; //player transform
    Vector3 deltaPos; // the difference between the ball and the object
    public Rigidbody rb; // gameObject rigidbody
    public float sensivityX;
    public float sensivityY;
    void Start()
    {
        deltaPos = transform.position - centerPosition.position; // the difference between the ball and the object

    }

    void Update()
    {
        rb.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * sensivityX * Time.fixedDeltaTime, 0));
        transform.position = centerPosition.position + deltaPos; // saving distance
    }
}

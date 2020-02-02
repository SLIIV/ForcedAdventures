using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class CheckpointRotationObject : MonoBehaviour
{
    public Rigidbody obj; 
    public float x;
    public float y;
    public float z;
    Vector3 angleRotation;
    void Start()
    {
        angleRotation = new Vector3(x, y, z);
    }

    void FixedUpdate()
    {
        Quaternion direction = Quaternion.Euler(angleRotation * Time.deltaTime );
        obj.MoveRotation(obj.rotation * direction);
    }
    void OnTriggerStay(Collider prop)
    {
        if (prop.CompareTag("Player"))
        {
            Quaternion direction = Quaternion.Euler(angleRotation * 3 * Time.deltaTime);
            obj.MoveRotation(obj.rotation * direction);
        }
    }
}

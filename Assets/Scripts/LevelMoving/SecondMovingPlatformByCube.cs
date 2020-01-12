using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMovingPlatformByCube : MonoBehaviour
{
    public Transform platform;
    public bool isPressed = false;

    void OnTriggerEnter(Collider prop)
    {
        if (prop.name == "SecondCube")
        {
            isPressed = true;
            platform.position = new Vector3(platform.position.x - 7f, platform.position.y, platform.position.z);
            gameObject.SetActive(false);
            Destroy(GameObject.Find(prop.name));
        }
    }
}

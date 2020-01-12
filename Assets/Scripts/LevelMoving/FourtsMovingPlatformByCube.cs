using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourtsMovingPlatformByCube : MonoBehaviour
{
    public Transform platform;
    ThirdMovingPlatformByCube TMPB;
    void Start()
    {
        GameObject check = GameObject.Find("ThirdPlate");
        TMPB = check.GetComponent<ThirdMovingPlatformByCube>();
    }

    void OnTriggerEnter(Collider prop)
    {
        if (TMPB.isPressed)
        {
            if (prop.name == "ThirdCube")
            {
                platform.position = new Vector3(platform.position.x, platform.position.y - 6, platform.position.z);
                gameObject.SetActive(false);
                Destroy(GameObject.Find(prop.name));
            }
        }
    }
}

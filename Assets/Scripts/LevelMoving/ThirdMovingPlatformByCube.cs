using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdMovingPlatformByCube : MonoBehaviour
{
    public Transform platform;
    public bool isPressed = false;
    FirstMovingPlatformByPlate FMPB;

    void Start()
    {
        GameObject check = GameObject.Find("FirstPlate");
        FMPB = check.GetComponent<FirstMovingPlatformByPlate>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider prop)
    {
        if (FMPB.isPressed)
        {
            if (prop.CompareTag("Player"))
            {
                isPressed = true;
                platform.position = new Vector3(platform.position.x, platform.position.y, platform.position.z - 7);
                gameObject.SetActive(false);

            }
        }
    }
}

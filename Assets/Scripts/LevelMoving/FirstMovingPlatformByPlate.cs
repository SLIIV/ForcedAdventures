using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMovingPlatformByPlate : MonoBehaviour
{
    public Transform platform;
    public bool isPressed = false;
    SecondMovingPlatformByCube SMPB;

    // Update is called once per frame
    private void Start()
    {
        GameObject check = GameObject.Find("SecondPlate");
        SMPB = check.GetComponent<SecondMovingPlatformByCube>();
    }
    private void OnTriggerEnter(Collider prop)
    {
        if (prop.name == "FirstCube")
        {
            //Debug.Log("Good one");
            if (SMPB.isPressed == true)
            {
                isPressed = true;
                platform.position = new Vector3(platform.position.x, platform.position.y, platform.position.z - 9);
                gameObject.SetActive(false);
                Destroy(GameObject.Find(prop.name));
            }
        }
    }
}

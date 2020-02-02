using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningWithCode : MonoBehaviour
{
    public bool isFirstNumber = false;
    public bool isSecondNumber = false;
    public bool isThirdNumber = false;
    public bool isFourthNumber = false;
    public AudioSource playerAudio;
    public AudioClip[] clips;
    bool isOpened = false;

    // Update is called once per frame
    void OnTriggerStay(Collider prop)
    {
        if (prop.CompareTag("Player"))
        {
            if(Input.anyKeyDown)
            {
                playerAudio.clip = clips[0];
                playerAudio.Play();
            }
            if (Input.GetKey(KeyCode.Alpha7))
                isFirstNumber = true;
            if (Input.GetKey(KeyCode.Alpha3) && isFirstNumber == true)
                isSecondNumber = true;
            if (Input.GetKey(KeyCode.Alpha0) && isSecondNumber == true)
                isThirdNumber = true;
            if (Input.GetKey(KeyCode.Alpha5) && isThirdNumber == true)
                isFourthNumber = true;
            if (isFirstNumber && isSecondNumber && isThirdNumber && isFourthNumber && !isOpened)
            {
                StartCoroutine(Rotator().GetEnumerator());
                playerAudio.clip = clips[1];
                playerAudio.Play();
                
            }
        }    
    }
    IEnumerable Rotator()
    {
        Quaternion direction = Quaternion.Euler(new Vector3(0, 0, -15f) * Time.deltaTime);
        for (float i = 0.0f; i < 2.0f; i += 0.2f)
        {
            gameObject.transform.rotation *= direction;
            yield return null;
        }
        isOpened = true;
    }
}

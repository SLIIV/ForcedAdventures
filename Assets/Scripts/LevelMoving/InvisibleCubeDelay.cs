using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleCubeDelay : MonoBehaviour
{
    public float delay;
    void OnCollisionEnter(Collision prop)
    {
        if (prop.collider.CompareTag("Player"))
        {
            if (CompareTag("Falling cube"))
            { 
                StartCoroutine(SetActiveOffByDelay(delay).GetEnumerator());

            }
            else
                Destroy(gameObject, delay);
        }
    }
    IEnumerable SetActiveOffByDelay(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        gameObject.SetActive(false);
        Invoke("SetActiveByDelay", time);
    }
    void SetActiveByDelay()
    {
        gameObject.SetActive(true);
    }

}

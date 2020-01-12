using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnding : MonoBehaviour
{

    public string LevelName;
    void OnTriggerEnter(Collider prop)
    {
        if (prop.CompareTag("Player"))
        {
            SceneManager.LoadScene(LevelName);
        }
    }
}

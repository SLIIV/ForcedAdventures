using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class Checkpoint : MonoBehaviour
{
    public int maxHealth; //health storing constant
    private int health;

    private AudioClip[] sounds;
    public AudioSource playerAudio;

    private int maxWorkCount = 1;

    /// <summary>
    /// Starting position
    /// </summary>
    private Vector3 spawnPoint; 
    private Vector3 checkPoint; // checkpoint position
    GameObject check; // checkpoint prefab
   

    void Awake()
    {
        sounds = GetComponent<PlayerController>().ambientSounds;
        spawnPoint = transform.position; // save our start position
        checkPoint = spawnPoint; // At the beggining of the game, our checkpoint poistion is start position
        check = GameObject.Find("Medal"); // Find checkpoint prefab
        health = maxHealth; // At the beggining of the game our healt is maxHealth
    }

    /// <summary>
    /// if object enter to the trigger collider
    /// </summary>
    /// <param name="prop">object</param>
    private void OnTriggerEnter(Collider prop)
    {
       
            if (prop.CompareTag("Checkpoint"))
            {
                playerAudio.clip = sounds[2];
                playerAudio.Play();
                checkPoint = transform.position;
                Rigidbody rb = prop.GetComponent<Rigidbody>();
                health = maxHealth;
            }

            if (prop.CompareTag("LosePosition")) // if player falled on lose area, him lives are taken away
            {
                if (maxWorkCount == 1)
                {
                playerAudio.Stop();
                playerAudio.clip = sounds[3];
                playerAudio.Play();
                maxWorkCount--;
                if (health > 0)
                {
                    health--;
                }
                if (health <= 0) // if the player’s lives are over, he returns to the starting position

                {
                    checkPoint = spawnPoint;
                    health = maxHealth;
                    check.SetActive(true); // returns checkpoints on their positions
                }
                transform.position = checkPoint;

                }
            }
        
    }
    /// <summary>
    /// If object exited trigger collider
    /// </summary>
    /// <param name="prop">object</param>
    private void OnTriggerExit(Collider prop)
    {
        if (prop.CompareTag("LosePosition"))
            maxWorkCount = 1;
        if (prop.CompareTag("Checkpoint")) // is player exited trigger collider, checkpoint's prefab disappears
        {
            check.SetActive(false);
        }
    }
}

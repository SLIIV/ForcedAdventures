using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb; //player rigidbody
    public Transform Camera; // main camera transform
    public float jumpForce; // jump forse
    private bool isGround; // is the player standing on the ground?

    public float speed; // playerSpeed
    private float startSpeed; // player start speed
    private float maxSpeed; // max player speed
    public float sensivityX; //|sensivity
    public float sensivityY; //|sensivity
    private AudioSource playerAudio;
    public AudioClip[] ambientSounds;

    void Awake()
    {
        startSpeed = speed; // at the beggining of the game we have a default speed
        maxSpeed = speed * 1.7f; // our max speed
        playerAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {

        if (Input.GetKeyUp(KeyCode.LeftShift))  // if we keyUp left shift we takes default speed
            speed = startSpeed;
        else if (Input.GetKeyDown(KeyCode.LeftShift)) // if we pressed left shift we takes acceleration
        {
            speed = maxSpeed;
        }
            
        if (Input.GetKey(KeyCode.W)) // forward movement relative to the camera
            rb.AddForce(new Vector3(Camera.forward.x * speed, 0, Camera.forward.z * speed) * Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.S)) // back movement relative to the camera
            rb.AddForce(new Vector3(Camera.forward.x * -speed, 0, Camera.forward.z * -speed) * Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.A)) // left movement relative to the camera
            rb.AddForce(new Vector3(Camera.right.x * -speed, 0, Camera.right.z * -speed) * Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.D)) // right movement relative to the camera
            rb.AddForce(new Vector3(Camera.right.x * speed, 0, Camera.right.z * speed) * Time.fixedDeltaTime);
        jump();
    }
    void jump()
    {
        Ray ray = new Ray(gameObject.transform.position, Vector3.down); // let down beam
        RaycastHit rayHit; // checking raycast hit
        if (Physics.Raycast(ray, out rayHit, 0.5f)) isGround = true; // if any object was seen in the  
        //radius of the ball, then the ball can jump
        else isGround = false; // else can't
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse); // push the ball up
            playerAudio.clip = ambientSounds[0];
            playerAudio.Play();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        playerAudio.clip = ambientSounds[1];
        if(!collision.collider.CompareTag("LosePosition"))
            playerAudio.Play();
    }
}

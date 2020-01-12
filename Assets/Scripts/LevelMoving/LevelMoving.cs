using UnityEngine;

public class LevelMoving : MonoBehaviour
{
    public float speed;
    private float direction;
    public Rigidbody rb;
    void Start()
    {
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(direction * speed * Time.deltaTime, 0, 0));
    }
    private void OnTriggerEnter(Collider wall)
    {
        if (wall.CompareTag("Wall"))
        {
            direction *= -1;
        }
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // * name our Rigidbody rb.
    }


    bool touchingGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.7f, groundLayer); // * sends a ray from my players body (first parameter); straight down (second parameter); with a 1.1 distance; the last parameter tells the raycast to ONLY hit things on the groundLayer
    }

    // Update is called once per frame
    void Update()
    {

        float x;  // * define x axis

        x = 0; // * initialize at 0


        if  (Input.GetKey(KeyCode.D)) x = 5; // * when touching D make x value 5
        if  (Input.GetKey(KeyCode.A)) x = -5; // * reverse that on A

        rb.linearVelocity = new Vector2(x, rb.linearVelocity.y); // * linear velocity is defined by the current x value and y's linear velocity (either 5 or null) allowing for in air movement

        if  (Input.GetKeyDown(KeyCode.W) && touchingGround()) // * if on the ground and we press w
        {
            rb.linearVelocity = new Vector2(x, 5); // * use whatever x's value we have along with 5 for jump force.
        }
    }
}

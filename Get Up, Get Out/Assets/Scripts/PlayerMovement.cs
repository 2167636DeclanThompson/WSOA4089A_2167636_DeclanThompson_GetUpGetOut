using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed;
    public float climbSpeed;
    private Rigidbody2D rb;
    public bool isGrabbing;
    public KeyCode grab = KeyCode.LeftShift;
    private Collision collisionScript;
    public BlockScript block;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collisionScript = GetComponent<Collision>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(x, y);
        Run(direction);                

        if (Input.GetKey(grab))
        {
            isGrabbing = true;
        }
        else
        {
            isGrabbing = false;
        }

        if (isGrabbing == true && collisionScript.onWall == true)
        {
            Climb(direction);
        }

        if (block.Climb == true)
        {
            Climb(direction);
        }

        if (isGrabbing == true && collisionScript.onCeiling == true)
        {
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Run(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * runSpeed, rb.velocity.y);
    }

    public void Climb(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, dir.y * climbSpeed); 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "goal")
        {
            Application.Quit();
        }
    }

}

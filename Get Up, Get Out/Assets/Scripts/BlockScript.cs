using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public GameObject player;
    public bool Climb;
    public bool Button;
    
    private void Update()
    {
        if (player.GetComponent<PlayerMovement>().isGrabbing == true && player.GetComponent<Collision>().onBlock == true)
        {
            if (Input.GetAxis("Horizontal") != 0 && Climb == false && player.GetComponent<Collision>().onGround == true)
            {
                this.GetComponent<FixedJoint2D>().enabled = true;
                this.GetComponent<FixedJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
            }
            else if (Input.GetAxis("Vertical") != 0)
            {
                this.GetComponent<FixedJoint2D>().enabled = false;
                Climb = true;
            }

        }
        else
        {
            this.GetComponent<FixedJoint2D>().enabled = false;
            Climb = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.name == "button")
        {
            Button = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "button")
        {
            Button = false;
        }
    }
}

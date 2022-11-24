using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float Speed;
    public bool movingUp = true;

    private void Start()
    {
        movingUp = true;
    }

    private void Update()
    {
        
            if (movingUp == true)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + Speed * Time.deltaTime);
            }
            else if (movingUp == false)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - Speed * Time.deltaTime);
            }
                       
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Waypoint" && movingUp == false)
        {
            movingUp = true;
        }
        else if (collider.gameObject.tag == "Waypoint" && movingUp == true)
        {
            movingUp = false;
        }
    }
}

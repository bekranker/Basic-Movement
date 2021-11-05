using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeMovement : MonoBehaviour
{
    public float speed; // it's your characters speed
    public float jumpAmount; // it's your character jump coefficient
    private Rigidbody2D rb; // this is our Rigidbody component
    bool IsGrounded = false; // we're checking to touching ground for jump.


    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>(); // we're connected the our Component
    }

    private void Update()
    {
        var X = Input.GetAxis("Horizontal") * Time.deltaTime; // it's getting Inputs from player.we're getting values and we're say them var X.
        //var Y = Input.GetAxis("Vertical") * Time.deltaTime; you should add axis y for your project.

        transform.position += new Vector3(X * speed, 0, 0); //this is chancing position for your character every second.



    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == true)
        {
            rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse); // we're adding some force for our character. but just for for up. 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // are we touch the ground ?
        if (collision.gameObject.name == "ground") //if answer's yes
        {
            IsGrounded = true; // change to true
        }

        
    }

    private void OnCollisionExit2D(Collision2D collisionE)
    {
        // are we break to touch the ground ?

        if (collisionE.gameObject.name == "ground") // if answer's yes
        {

            IsGrounded = false; // change to false

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; // it's your characters speed
    public float jumpAmount; // it's your character jump coefficient
    private Rigidbody2D rb; // this is our Rigidbody component
    public LayerMask GroundLayer;
    public Transform feetPos;
    public float checkRadius;
    bool IsGrounded;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>(); // we're connected the our Component
    }

    private void Update()
    {
        var X = Input.GetAxis("Horizontal") * Time.deltaTime; // it's getting Inputs from player.we're getting values and we're say them var X.
        var Y = Input.GetAxis("Vertical") * Time.deltaTime; //you should add y axis for your project.

        transform.position += new Vector3(X * speed, Y * speed, 0); //this is chancing position for your character every second.


    }

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, GroundLayer); // thats for jumping.

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse); // we're adding some force for our character. but just for for up. 
        }
    }


}

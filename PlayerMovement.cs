using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; 
    public float jumpAmount; 
    private Rigidbody2D rb; 
    public LayerMask GroundLayer;
    public Transform feetPos;
    public float checkRadius;
    bool IsGrounded;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        var X = Input.GetAxis("Horizontal") * Time.deltaTime; 
        var Y = Input.GetAxis("Vertical") * Time.deltaTime;

        transform.position += new Vector3(X * speed, Y * speed, 0);


    }

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, GroundLayer); 

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);
        }
    }


}

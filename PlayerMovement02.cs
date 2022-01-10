using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("------For_Prefabs------")]
    [SerializeField] GameObject explosion;




    [Header("-----For_Movement-----")]
    [SerializeField] Vector2 minPower;
    [SerializeField] Vector2 maxPower;
    [SerializeField] float power;

    Vector3 startPos;
    Vector3 endPos;
    Vector2 force;

    Camera cam;
    Rigidbody2D rb;




    [Header("-----For_Jumping-----")]
    [SerializeField] LayerMask GroundLayer;
    [SerializeField] Transform feetPos;
    [SerializeField] float checkRadius;
    [SerializeField] float jumpAmount;


    bool IsGrounded;




    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>(); // we're connected the our Component
        cam = Camera.main;
    }

    private void Update()
    {

        if (IsGrounded)
        {
            playerMovement();
        }


        else
        {

            Vector3 a = cam.ScreenToWorldPoint(Input.mousePosition);
            float a_Diffuce = Mathf.Clamp(a.x, -8.5f, 8.5f);
            Vector2 b = new Vector2(a_Diffuce, 0);

            rb.AddForce(b * Time.deltaTime, ForceMode2D.Impulse);


            //transform.position += new Vector3(a_Diffuce * Time.deltaTime, 0, 0); 


        }

    }

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, GroundLayer); // thats for jumping.
    }



    public void playerMovement()
    {

        if (Input.GetMouseButtonDown(0))
        {
            startPos = cam.ScreenToWorldPoint(Input.mousePosition);
            startPos.z = -10f;

        }


        if (Input.GetMouseButtonUp(0))
        {
            endPos = cam.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = -10f;


            force = new Vector2(Mathf.Clamp(startPos.x - endPos.x, minPower.x, maxPower.x), Mathf.Clamp(startPos.y - endPos.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "nemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            Instantiate(explosion, transform.position, Quaternion.identity);

        }
    }

}

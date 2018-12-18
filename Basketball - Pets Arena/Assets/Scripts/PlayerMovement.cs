using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //public GameObject[] playerActive;

    public float Speed, jump;
    Rigidbody2D rb;
    float hInput = 0;
    Anim anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.3f;
    int whatIsGround;

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<Anim>();
        rb = GetComponent<Rigidbody2D>();
        whatIsGround = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        Move(hInput);

    }



    public void Move(float horizontalInput)
    {

        rb.velocity = new Vector2(horizontalInput * Speed, rb.velocity.y);

    }

    public void Jump()
    {
        if (grounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            anim.anim.Play("Jump");
        }

    }
    public void StartMoving(float horizontalInput)
    {

        hInput = horizontalInput;

    }

}

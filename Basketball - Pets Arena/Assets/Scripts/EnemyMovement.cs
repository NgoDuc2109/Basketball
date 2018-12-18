using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject ball;
    public float tem1, tem2;

    public EventBatBong ev;
    public float Speed, jump;
    Rigidbody2D rb;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.3f;
    int whatIsGround;
    Anim anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Anim>();
        whatIsGround = LayerMask.GetMask("Ground");
    }
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (!IsInvoking("Waiting"))
        {
            try
            {
                if (ev.obj == null || (ev.obj != null && ev.obj != transform))
                {
                    
                    if (transform.position.x < ball.gameObject.transform.position.x)
                    {
                        Invoke("Waiting", Random.Range(tem1, tem2));
                        MoveClone(1);

                    }
                    else
                    {
                        Invoke("Waiting", Random.Range(tem1, tem2));
                        MoveClone(-1);

                    }
                }
                else
                {


                        if (transform.position.x <= -15)
                        {

                            Invoke("Waiting", Random.Range(tem1, tem2));
                            MoveClone(1);
                        }
                        else
                        {
                            Invoke("Waiting", Random.Range(tem1, tem2));
                            MoveClone(-1);
                        }
                    

                }

            }
            catch (System.Exception)
            {

                if (transform.position.x < ball.gameObject.transform.position.x)
                {
                    Invoke("Waiting", Random.Range(tem1, tem2));
                    MoveClone(1);

                }
                else
                {
                    Invoke("Waiting", Random.Range(tem1, tem2));
                    MoveClone(-1);

                }
            }

        }

    }

    public void MoveClone(float horizontalInput)
    {
        if (horizontalInput < 0 && grounded == true)
        {
            rb.velocity = new Vector2(horizontalInput * Speed, jump);
            anim.anim.Play("Jump");
        }
        if (horizontalInput > 0 && grounded == true)
        {
            rb.velocity = new Vector2(horizontalInput * Speed, jump);
            anim.anim.Play("Jump");
        }
    }
    void Waiting()
    { }
}

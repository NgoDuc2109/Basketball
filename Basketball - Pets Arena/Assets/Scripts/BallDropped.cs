using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDropped : MonoBehaviour
{

    public static int PlayerIndex , EnemyIndex ;
    public EventBatBong events;
    public PhysicsMaterial2D ballBall;

    void Awake()
    {
        PlayerIndex = 0;
        EnemyIndex = 0;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            if (other.tag == "Ball" && transform.position.y < other.transform.position.y && other.transform.parent.parent.parent.parent.transform.position.x > 0 && other.transform.parent.parent.parent.parent.gameObject.tag == "Player")
            {

                    events.obj = null;
                    events.enabled = false;
                    other.gameObject.AddComponent<Rigidbody2D>();
                    other.gameObject.GetComponent<Rigidbody2D>().sharedMaterial = ballBall;
                    other.transform.SetParent(null);
                    PlayerIndex++;

            }
            else if (other.tag == "Ball" && transform.position.y < other.transform.position.y && other.transform.parent.parent.parent.parent.transform.position.x < 0 && other.transform.parent.parent.parent.parent.gameObject.tag == "Enemy")
            {

                    events.obj = null;
                    events.enabled = false;
                    other.gameObject.AddComponent<Rigidbody2D>();
                    other.gameObject.GetComponent<Rigidbody2D>().sharedMaterial = ballBall;
                    other.transform.SetParent(null);
                    EnemyIndex++;
            }


        }
        catch (Exception ex)
        {

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ball"&& transform.position.y < other.transform.position.y)
        {
                events.enabled = true;
                PlayerIndex = 0;
                EnemyIndex = 0;
        }

    }
}

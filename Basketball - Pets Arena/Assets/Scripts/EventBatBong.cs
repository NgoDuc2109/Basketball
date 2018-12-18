using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBatBong : MonoBehaviour {
    [SerializeField]
    Rigidbody2D rb;
    bool grounded = false;
    float groundRadius = 0.875f;
    Collider2D arm;
    int whatIsArm;
    public  Transform obj;
    // Update is called once per fram
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        whatIsArm = LayerMask.GetMask("Arm");

    }

    // Update is called once per frame
    void Update()
    {

        try
        {
            if ((arm = Physics2D.OverlapCircle(transform.position, groundRadius, whatIsArm)) != null)
            {

                obj = arm.transform.parent.parent.parent;
                transform.SetParent(arm.transform);
                transform.localPosition = Vector3.zero;
                Destroy(rb);
            }
        }
        catch 
        {


        }
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public int tipo;
    private PlayerController player;
    private PC2 player2;
    private Rigidbody2D rb2d;
    private Transform i;
    // Start is called before the first frame update
    void Start()
    {

        if (tipo == 0)
        {
            player = GetComponentInParent<PlayerController>();
        }
        else
        {
            player2 = GetComponentInParent<PC2>();
        }

        rb2d = GetComponentInParent<Rigidbody2D>();
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            rb2d.velocity = new Vector3(0, 0, 0);

            if (tipo == 0)
            {
                player.transform.parent = collision.transform;
                player.grounded = true;

            }
            else
            {
                player2.transform.parent = collision.transform;
                player2.grounded = true;

            }

        }
    }

    // Update is called once per frame
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" )
        {
            if (tipo == 0)
            {
                player.grounded = true;

            }
            else
            {
                player2.grounded = true;
            }

        }
        if (collision.gameObject.tag == "Platform")
        {
            if (tipo == 0)
            {
                player.transform.parent = collision.transform;

                player.grounded = true;
            }
            else
            {
                player2.transform.parent = collision.transform;

                player2.grounded = true;
            }
           
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" )
        {
            if (tipo == 0)
            {
                player.grounded = false;
            }
            else
            {
                player2.grounded = false;

            }
        }
        if (collision.gameObject.tag == "Platform" )
        {
            if (tipo == 0)
            {
                player.transform.parent = null;
                player.grounded = false;
            }
            else
            {
                player2.transform.parent = null;
                player2.grounded = false;
            }
        }

    }

}
    
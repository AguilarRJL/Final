using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private PlayerController player;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" && player!=null)
        {
            rb2d.velocity = new Vector3(0, 0, 0);
            player.transform.parent = collision.transform;
            player.grounded = true;
        }
    }

    // Update is called once per frame
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && player!=null)
        {
            player.grounded = true;
        }
        if (collision.gameObject.tag == "Platform" && player!=null)
        {
            player.transform.parent = collision.transform;
            player.grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && player!=null)
        {
           player.grounded = false;
        }
        if (collision.gameObject.tag == "Platform" && player!=null)
        {
            player.transform.parent = null;
            player.grounded = false;
        }

    }

}
    
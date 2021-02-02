using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 75f;
    public float jumpPower = 6.5f;
    public float MaxSpeed = 10;
    public string tipo;
    private Rigidbody2D rb2d;
    private Vector2 last;


    public bool grounded=true;
    public bool jump=false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        last = transform.position;
    }

    // Update is called once per frame
    

    private void Update()
    {
      /*if (grounded)
       {
                jump = true;
       }*/

        if (Input.GetKeyDown(KeyCode.Space) && gameObject.name=="Player2")
        {
            if (grounded)
            {
                jump = true;
            }
        }

      


    }

    private void FixedUpdate()
    {
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= .05f;

        if (grounded)
        {
            rb2d.velocity = fixedVelocity;
        }

        float h = Input.GetAxis("Horizontal");

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        rb2d.AddForce(Vector2.right * speed * h);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -MaxSpeed, MaxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (jump && gameObject.name=="Player2")
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;

        }

    }

    private void OnBecameInvisible()
    {
        transform.position = last;
    }

}

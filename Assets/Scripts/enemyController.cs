using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float maxSpeed = 1f;
    public float speed = 1f;
    public Vector2 offset;
    private Rigidbody2D rb2d;
    private Animator anim;
    public bool die = false;
        
    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        offset = new Vector2(10,0);
    
    }

    private void Update()
    {
        if (die)
        {
            anim.SetBool("Muerte", true);
            Destroy(gameObject, .6f);
        }
       
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * speed);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed,rb2d.velocity.y);


        if(rb2d.velocity.x >-.1f && rb2d.velocity.x < .1f)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

        }

        if (speed > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (speed < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }


    }
}

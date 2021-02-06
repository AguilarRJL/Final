using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bomba;
    public float speed = 75f;
    public float jumpPower = 6.5f;
    public float MaxSpeed = 10;
    public string tipo;
    private Rigidbody2D rb2d;
    private Vector2 last;

    public int numBombas;
    public int numVidas;

    public int dir = 0;

    public bool grounded=true;
    public bool jump=false;
    // Start is called before the first frame update
    void Start()
    {
        numBombas = 5;
        Debug.Log(numBombas.ToString());
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (numBombas > 0 && bomba!= null)
            {

                var i = dir == 0 ? .5f : -.5f;

                var obj = Instantiate(bomba, new Vector2(transform.position.x+i, transform.position.y+.5f), Quaternion.identity);

                if (dir == 0)
                {
                    obj.GetComponent<Bomba>().directionI = Vector3.right;
                }
                else
                {
                    obj.GetComponent<Bomba>().directionI = Vector3.left;
                }
                numBombas--;
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
            dir = 0;
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            dir = 1;
        }

        rb2d.AddForce(Vector2.right * speed * h);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -MaxSpeed, MaxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (jump)
        {
            
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Vidas")
        {
            numVidas++;
            numVidas = numVidas > 5 ? 5 : numVidas;
            Debug.Log(numVidas.ToString());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            numVidas--;
            numVidas = numVidas < 0 ? 0 : numVidas;
            Debug.Log(numVidas.ToString());
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "CheckPoint")
        {
            last = collision.gameObject.transform.position;
        }

        if (collision.gameObject.tag == "Cascada")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled=false;
            gameObject.GetComponentInChildren<CircleCollider2D>().enabled=false;
            numVidas--;
        }
    }
    private void OnBecameInvisible()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponentInChildren<CircleCollider2D>().enabled = true;
        transform.position = last;
        

    }

}

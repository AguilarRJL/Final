using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC2 : MonoBehaviour
{
    public float speed = 75f;
    public float jumpPower = 6.5f;
    public float MaxSpeed = 10;
    public string tipo;
    public int numSaltos = 100;
    public int numVidas = 3;
    public bool turno;


    private Rigidbody2D rb2d;
    private Animator anim;
    private Vector2 last;


    public bool grounded = true;
    public bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        last = transform.position;
        anim = GetComponent<Animator>();
        turno = true;
    
    }

    // Update is called once per frame


    private void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
        /*if (grounded)
         {
                  jump = true;
         }*/

        if (Input.GetKeyDown(KeyCode.Space) &&numSaltos>0)
        {
            numSaltos--;
//            numSaltos= numSaltos==0?0:numSaltos--;
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
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        rb2d.AddForce(Vector2.right * speed * h);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -MaxSpeed, MaxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (jump )
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Elimina")
        {
            EnemyFly enF = collision.gameObject.GetComponent<EnemyFly>();
            enF.muere = true;

        }
        if (collision.gameObject.tag == "Da�a")
        {
            numVidas--;
            transform.position = last;

        }

        if (collision.gameObject.tag == "Vidas")
        {
            numVidas++;
            numVidas = numVidas > 5 ? 5 : numVidas;
            Debug.Log(numVidas.ToString());
            Destroy(collision.gameObject);
        }
       /* if(collision.gameObject.tag == "Enemy")
        {
            numVidas--;
            numVidas = numVidas < 0 ? 0 : numVidas;
            Debug.Log(numVidas.ToString());
            Destroy(collision.gameObject);
        }*/

        if (collision.gameObject.tag == "CheckPoint")
        {
            Debug.Log("Tocado el CHKP");
            last = collision.gameObject.transform.position;
            CheckPointControl cpc = collision.gameObject.GetComponent<CheckPointControl>();
            cpc.toque = true;
        }
        if (collision.gameObject.tag == "Saltos")
        {
            Destroy(collision.gameObject);
            numSaltos++;
        }
        
        if (collision.gameObject.tag == "Cascada")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponentInChildren<CircleCollider2D>().enabled = false;
            numVidas--;
        }


    }
    private void OnBecameInvisible()
    {
        if (turno)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponentInChildren<CircleCollider2D>().enabled = true;
            transform.position = last;
        }
    }
}

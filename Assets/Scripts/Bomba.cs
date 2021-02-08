using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public Vector3 directionI;
    public float speed = 5;
    public Vector3 launchOffset;
    public bool thrown=true;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        var direction = directionI + Vector3.up;

        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);

        /*   if (thrown)
           {
           }

           transform.Translate(launchOffset);
           Destroy(gameObject, 10);*/

    }

    // Update is called once per frame
    void Update()
    {
       // if (!thrown)
        //{
            transform.position += directionI * speed * Time.deltaTime;
        //}        

        Destroy(gameObject, 10);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemyController>().die = true;
            //Destroy(collision.gameObject,.2f);
            AutoDestroy();
        }

    }
    void AutoDestroy()
    {
        anim.SetBool("Explode", true);
        Destroy(gameObject, .5f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject target;

    private Animator anim;
    private BoxCollider2D BC2D;
       
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        BC2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Cambio",true);
            BC2D.enabled = false;
            Destroy(target);
        }
        
    }



}

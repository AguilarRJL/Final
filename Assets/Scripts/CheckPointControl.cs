using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointControl : MonoBehaviour
{

    public bool toque;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        toque = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (toque)
        {
            animator.SetBool("Toque", true);
            GetComponent<Collider2D>().enabled = false;
        }
     
    }
}

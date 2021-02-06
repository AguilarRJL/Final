using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float ContadorT = 1f;
    public float ContadorT2 = .3f;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ContadorT -= Time.deltaTime*2;
        ContadorT2 -= Time.deltaTime ;

        if (ContadorT2 <= 0)
        {
            AutoDestroy();
           
        }
        if (ContadorT <= 0)
        {
            Destroy(gameObject);

        }
    }

    void AutoDestroy()
    {
        anim.SetBool("Explode", true);
    }

}

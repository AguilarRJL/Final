using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float speed;
    public bool dir = true;
    public bool muere = false;
    private Animator anim;

    // Start is called before the first frame update

    private Vector3 start, end;

    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }

        anim = GetComponentInChildren<Animator>();

    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }

        if (transform.position == target.position)
        {
            dir = !dir;
            target.position = (target.position == start) ? end : start;
        }
        if (dir == true)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (dir == false)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (muere)
        {
            anim.SetBool("Muere", true);
            Destroy(gameObject, .6f);
        }

    }
}

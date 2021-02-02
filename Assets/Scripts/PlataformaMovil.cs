using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float speed;
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
            target.position = (target.position == start) ? end : start;
        }


    }
    // Update is called once per frame
    void Update()
    {

    }
}

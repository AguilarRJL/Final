using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string tipo;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (tipo == "Jugador2")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.AddForce(Vector2.up, ForceMode2D.Impulse);
            }
        }


        float h = Input.GetAxis("Horizontal");

        if (h < 0)
        {
            transform.Translate(Vector3.left * h*Time.deltaTime*10);
        }

        if (h > 0)
        {
            transform.Translate(Vector3.left * h*Time.deltaTime*10);
        }


    }

}

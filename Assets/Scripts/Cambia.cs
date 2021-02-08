using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambia : MonoBehaviour
{
    public GameObject camara;
    public GameObject player1;
    public GameObject player2;


  

    public int currPlayer;
    private bool cambiar;

    // Start is called before the first frame update
    void Start()
    {
        currPlayer = 1;
        cambiar = false;

        player1.GetComponent<PlayerController>().enabled = false;
     //   player2.GetComponent<PlayerController>().enabled = true;*/

        FollowPlayer c = camara.GetComponent<FollowPlayer>();
        c.follow = player2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currPlayer = currPlayer + 1;
            currPlayer = currPlayer % 2 == 0 ? 0 : 1;
           
            cambiar = true;
        }

        

    }

    private void FixedUpdate()
    {
        if (cambiar)
        {
            Change();
            cambiar = false;
        }
    }

    void Change()
    {
        if (currPlayer == 0)
        {
            player1.GetComponent<PlayerController>().enabled = true;
            player1.GetComponent<PlayerController>().turno = true;

            player2.GetComponent<PC2>().enabled = false;
            player2.GetComponent<PC2>().turno = false;

            FollowPlayer c = camara.GetComponent<FollowPlayer>();
            c.follow = player1;
        }

        if (currPlayer == 1)
        {
            player1.GetComponent<PlayerController>().enabled = false;
            player1.GetComponent<PlayerController>().turno = false;


            player2.GetComponent<PC2>().enabled = true;
            player2.GetComponent<PC2>().turno = true;

            FollowPlayer c = camara.GetComponent<FollowPlayer>();
            c.follow = player2;

        }
    }

}

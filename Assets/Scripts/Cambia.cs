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
        currPlayer = 0;
        cambiar = false;
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

    private void LateUpdate()
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
            player1.AddComponent<PlayerController>();
            if (player2.GetComponent<PlayerController>() != null)
            {
                Destroy(player2.GetComponent<PlayerController>());
            }
            FollowPlayer c= camara.GetComponent<FollowPlayer>();
            c.follow = player1;
        }

        if (currPlayer == 1)
        {
            player2.AddComponent<PlayerController>();
            if (player1.GetComponent<PlayerController>() != null)
            {
                Destroy(player1.GetComponent<PlayerController>());
            }
            FollowPlayer c = camara.GetComponent<FollowPlayer>();
            c.follow = player2;

        }
    }

}

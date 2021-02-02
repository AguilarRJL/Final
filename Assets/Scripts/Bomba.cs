using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float ContadorT = 10;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ContadorT -= Time.deltaTime;
        if (ContadorT <= 0)
        {
            AutoDestroy();
        }
    }

    void AutoDestroy()
    {
        if (explosion != null )
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}

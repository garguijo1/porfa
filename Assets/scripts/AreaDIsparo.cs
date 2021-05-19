using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDIsparo : MonoBehaviour
{
    public EnemiShot[] enemigos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            for(int i = 0; i < enemigos.Length; i++)
            {
                enemigos[i].moverse = true;
                enemigos[i].disparar = true;

            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            for (int i = 0; i < enemigos.Length; i++)
            {
                enemigos[i].moverse = false;
                enemigos[i].disparar = false;

            }

        }

    }
}

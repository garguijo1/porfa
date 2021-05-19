using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaLava : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    public float altura;
    public Transform p;

    private bool arriba;
    private bool abajo;

    void Start()
    {
        arriba = true;
        abajo = true;
       rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= (p.position.y + altura) && arriba)
        {

            transform.localScale = new Vector2(1, -1);
            //rig.velocity = transform.up * -speed * Time.deltaTime;
            speed *= -1;
            arriba = false;
            abajo = true;
        }
         
        if(transform.position.y <= p.position.y && abajo)
        {
            transform.localScale = new Vector2(1, 1);
            //rig.velocity = transform.up * speed * Time.deltaTime;
            speed *= -1;
            arriba = true;
            abajo = false;
        }

        rig.velocity = transform.up * speed * Time.deltaTime;



        


    }

}

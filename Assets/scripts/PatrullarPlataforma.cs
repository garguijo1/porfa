using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullarPlataforma : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;

    public Transform PuntoA;
    public Transform PuntoB;

    private bool moveToA = false;
    private bool moveToB = false;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        moveToA = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveToA)
        {

            transform.eulerAngles = new Vector3(0, 180, 0);

            rig.transform.position = Vector2.MoveTowards(transform.position, PuntoA.position, speed * Time.deltaTime);

            if(transform.position.x == PuntoA.position.x)
            {
                moveToA = false;
                moveToB = true;
            }

        }

        if (moveToB)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rig.transform.position = Vector2.MoveTowards(transform.position, PuntoB.position, speed * Time.deltaTime);

            if (transform.position.x == PuntoB.position.x)
            {
                moveToB = false;
                moveToA = true;
            }

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("pisadooooooooooooo");
            Destroy(gameObject, 0f);
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200f));
        }

    }



}

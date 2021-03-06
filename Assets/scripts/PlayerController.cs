using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //public Text conteo;
    // public Text win;

    public float fuerzaDesplazamiento;
    public float fuerzaSalto;

    private int punto;
    private Vector3 posicion;


    private bool salto = true;
    private bool inicio = true;
    // Start is called before the first frame update
    void Start()
    {
        punto = 0;
        SetCountText();
       // win.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-fuerzaDesplazamiento * Time.deltaTime, 0));

        }

        if (Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaDesplazamiento * Time.deltaTime, 0));
        }

        if (Input.GetKeyDown("up") && salto )
        {

            salto = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.transform.tag == "piso")
        {
            salto = true;
        }

        if (collision.transform.tag == "daño")
        {
            salto = false;
            gameObject.GetComponent<Transform>().transform.position = posicion;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("moneda"))
        {
            collision.gameObject.SetActive(false);
            punto = punto + 1;
            SetCountText();
        }

       if (collision.gameObject.CompareTag("agua"))
        {
            salto = false;
        }

        if (collision.gameObject.CompareTag("daño"))
        {
            salto = false;
            gameObject.GetComponent<Transform>().transform.position = posicion;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (collision.gameObject.CompareTag("spawn") && inicio)
        {
            posicion = collision.gameObject.GetComponent<Transform>().transform.position; 

        }

        if (collision.gameObject.CompareTag("check"))
        {
            inicio = false;
            posicion = collision.gameObject.GetComponent<Transform>().transform.position;

        }
    }

    void SetCountText()
    {
      // conteo.text = "Puntos: " + punto.ToString();
        if(punto >= 5)
        {
            //win.text = "GANASTE";
        }
    }

}

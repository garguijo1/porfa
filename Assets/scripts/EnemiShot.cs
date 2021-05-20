using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiShot : MonoBehaviour
{
    public Transform player_pos;
    public float speed;
    public float dis_frenado;
    public float dis_retraso;

    public Transform punto_instancia;
    public GameObject bala;
    private float tiempo;

    public bool disparar;
    public bool moverse;


    // Start is called before the first frame update
    void Start()
    {
        player_pos = GameObject.Find("player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento

        if (moverse)
        {

            if (Vector2.Distance(transform.position, player_pos.position) > dis_frenado)
            {
                transform.position = Vector2.MoveTowards(transform.position, player_pos.position, speed * Time.deltaTime);
            }

            if (Vector2.Distance(transform.position, player_pos.position) < dis_retraso)
            {
                transform.position = Vector2.MoveTowards(transform.position, player_pos.position, -speed * Time.deltaTime);
            }

            if (Vector2.Distance(transform.position, player_pos.position) < dis_frenado && Vector2.Distance(transform.position, player_pos.position) > dis_retraso)
            {
                transform.position = transform.position;
            }

            //flip


            if (player_pos.position.x > this.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                //this.transform.localScale = new Vector2(0.5f , 0.5f);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                // this.transform.localScale = new Vector2(-0.5f, 0.5f);
            }
        }


        if (disparar)
        {

            tiempo += Time.deltaTime;
            if (tiempo >= 2)
            {
                Instantiate(bala, punto_instancia.position, punto_instancia.rotation);
                tiempo = 0;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("pisadooooooooooooo");
            Destroy(gameObject, 0f);
        }

    }

}

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


    // Start is called before the first frame update
    void Start()
    {
        player_pos = GameObject.Find("player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento

        if(Vector2.Distance(transform.position , player_pos.position) > dis_frenado)
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

        //disparo

        tiempo += Time.deltaTime;
        if (tiempo >= 2)
        {
            Instantiate(bala,punto_instancia.position, punto_instancia.rotation);
            tiempo = 0;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoNadar : MonoBehaviour
{
    public GameObject[] puntos;
    int random;
    public float speed;
    public float espera;
    float tiempo;

    // Start is called before the first frame update
    void Start()
    {
        //puntos = GameObject.FindGameObjectsWithTag("puntos");
        random = Random.Range(0, puntos.Length);
    }

    // Update is called once per frame
    void Update()
    {

        if(puntos[random].transform.position.x > this.transform.position.x)
        {
            this.transform.localScale = new Vector2(1, 1);
        }
        else
        {
            this.transform.localScale = new Vector2(-1, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position, puntos[random].transform.position, speed * Time.deltaTime);
       

        if (Vector2.Distance(transform.position, puntos[random].transform.position) < 0.25f)
        {
            tiempo += Time.deltaTime;
            if (tiempo >= espera)
            {
                random = Random.Range(0, puntos.Length);
                tiempo = 0;
            }
        }
    }
}

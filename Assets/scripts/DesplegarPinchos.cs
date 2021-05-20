using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplegarPinchos : MonoBehaviour
{

    public float velSubida;
    public float velBajada;
    public float tiempo;
    public bool techo;


    private Rigidbody2D rig;

    private float time;

    private Vector3 aux;
    private Vector3 aux2;

    private bool arriba;
    private bool abajo;

    // Start is called before the first frame update
    void Start()
    {
        if (techo)
        {
            aux2 = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            aux = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            aux2 = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            aux = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        
        arriba = true;
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= tiempo)
        {
            if (arriba)
            {


                rig.transform.position = Vector2.MoveTowards(transform.position, aux2, velSubida * Time.deltaTime);

                if (transform.position.y == aux2.y)
                {
                   
                    arriba = false;
                    abajo = true;
                    time = 0;
                }
            }
            
        } 
      
            
       

        if (abajo)
        {

                rig.transform.position = Vector2.MoveTowards(transform.position, aux, velBajada * Time.deltaTime);

                if (transform.position.y == aux.y)
                {
                   
                    arriba = true;
                    abajo = false;
                }

        }

    }
}

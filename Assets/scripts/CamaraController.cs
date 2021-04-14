using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public GameObject personaje;
    public Vector2 minCamPos, maxCamPos;
    public float suavizado;
    private Vector2 velocidad;

   // private Vector3 posicion;
    // Start is called before the first frame update
    void Start()
    {
        //posicion = transform.position - personaje.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float posx = Mathf.SmoothDamp(transform.position.x,
            personaje.transform.position.x,ref velocidad.x, suavizado);
        float posy = Mathf.SmoothDamp(transform.position.y,
            personaje.transform.position.y, ref velocidad.y, suavizado);
        //float posx = personaje.transform.position.x;
        //float posy = personaje.transform.position.y;

        transform.position = new Vector3(Mathf.Clamp(posx,minCamPos.x,maxCamPos.x),
                                         Mathf.Clamp(posy,minCamPos.y,maxCamPos.y), 
                                        transform.position.z);

        //transform.position = personaje.transform.position + posicion;
    }
}

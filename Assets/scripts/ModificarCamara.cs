using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificarCamara : MonoBehaviour
{
    public CamaraController camara;
    public Vector2 minPos, maxPos;
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
        if(collision.gameObject.tag == "Player")
        {
            camara.minCamPos = minPos;
            camara.maxCamPos = maxPos;
        }
    }


}

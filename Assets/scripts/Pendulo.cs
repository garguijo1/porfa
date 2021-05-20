using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulo : MonoBehaviour
{

    private Rigidbody2D rig;
    public float limiteIzq;
    public float limiteDer;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.angularVelocity = 500;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        if (transform.rotation.z < limiteDer && rig.angularVelocity > 0 && rig.angularVelocity < speed)
        {
            rig.angularVelocity = speed;
        }
        else if (transform.rotation.z > limiteIzq && rig.angularVelocity < 0 && rig.angularVelocity > -speed)
        {
            rig.angularVelocity = -speed;
        }
    }
}

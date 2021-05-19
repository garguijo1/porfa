using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{

    private Rigidbody2D rig;
    public float speed;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject, 0f);
    }
}

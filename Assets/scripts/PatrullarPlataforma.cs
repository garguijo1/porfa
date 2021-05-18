using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullarPlataforma : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "piso")
        {
            speed *= -1;
            this.transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
        }
      

    }

}

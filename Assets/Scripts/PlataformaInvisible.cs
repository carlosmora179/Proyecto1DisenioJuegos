using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaInvisible : MonoBehaviour
{
    public Renderer rend1;
    public Renderer rend2;
    public Renderer rend3;
    public GameObject orbe;

    private Color color;
    public Collider2D coll2d;
    // Start is called before the first frame update
    void Start()
    {
        //rend = transform.GetComponentInChildren<Renderer>();
        rend1.material.color = color;
        rend2.material.color = color;
        rend3.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (orbe != null) {
            color = orbe.GetComponent<Orbe>().color;
            Debug.Log (color);
            rend1.material.color = color;
            rend2.material.color = color;
            rend3.material.color = color;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Renderer>().material.color == color)
        {
            Debug.Log("Tenemos el mismo color");
            coll2d.enabled = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        coll2d.enabled = false;
    }
}

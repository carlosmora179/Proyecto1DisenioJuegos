using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedInvisible : MonoBehaviour
{
    public Renderer rend1;
    public Renderer rend2;
    public Renderer rend3;
    public GameObject orbe;
    public Collider2D coll2d;

    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        color = orbe.GetComponent<Orbe>().color;
        rend1.material.color = color;
        rend2.material.color = color;
        rend3.material.color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Renderer>().material.color == color) {
            coll2d.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        coll2d.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbe : MonoBehaviour
{
    public Renderer rend;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        rend = transform.GetComponentInChildren<Renderer>();
        rend.material.color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player"){

            collision.GetComponent<Renderer>().material.color = color;
            collision.GetComponent<colorController>().pintado = true;
            collision.GetComponent<colorController>().cronometro = 10f;


        }
    }
}

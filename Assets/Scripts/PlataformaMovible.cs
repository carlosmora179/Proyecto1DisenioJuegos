using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovible : MonoBehaviour
{
    public Renderer rend;
    public Rigidbody2D rb2;
    public GameObject orbe;
    private Color color;
    private float cronometro;
    private bool salir;
    public Vector3 respawn;
    

    // Start is called before the first frame update
    void Start()
    {
        color = orbe.GetComponent<Orbe>().color;
        rend.material.color = color;
        cronometro = 1;
        salir = false;
        respawn = transform.position;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Renderer>() != null)
        {
            if (collision.collider.GetComponent<Renderer>().material.color == color)
            {
                rb2.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
                salir = false;
                cronometro = 1;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        salir = true;
        
    }

    private void Update()
    {
        if (salir)
        {
            if (cronometro < 0)
            {
                rb2.constraints |= RigidbodyConstraints2D.FreezePositionX;
                cronometro = 1;
                salir = false;
            }
            else
            {
                cronometro -= Time.deltaTime;
            }
        }
      
    }

    public void Respawn()
    {
        this.transform.position = respawn;
    }
}

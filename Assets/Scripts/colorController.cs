using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorController : MonoBehaviour
{
    public float cronometro = 0;
    public bool pintado = false;
    Rigidbody2D r2d;
    bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = GetComponent<MovimientoPlayer>().isGrounded;
        if (cronometro < 1)
        {
            cronometro = 0f;
            if (pintado)
            {
                GetComponent<Renderer>().material.color = Color.white;
                if(isGrounded){

                    r2d.velocity = new Vector2(r2d.velocity.x, 2f);

                }
                
                pintado = false;
            }
        }
        else
        {
            cronometro -= Time.deltaTime;
        }
    }
}

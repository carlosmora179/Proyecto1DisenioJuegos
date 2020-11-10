using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorController : MonoBehaviour
{
    public float cronometro = 0;
    public bool pintado = false;
    Rigidbody2D r2d;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cronometro <= 0)
        {
            if (pintado)
            {
                GetComponent<Renderer>().material.color = Color.white;
                r2d.velocity = new Vector2(r2d.velocity.x, 1f);
                pintado = false;
            }
        }
        else
        {
            cronometro -= Time.deltaTime;
        }
    }
}

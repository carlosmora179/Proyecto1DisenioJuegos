using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VidaPlayer : MonoBehaviour
{


    int vidaActual ;
    

    // Start is called before the first frame update
    void Awake()
    {
        vidaActual = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaActual <= 0 ){

            Debug.Log("Muerto");
        }
    }
    public void TakeDamage(int damage){
        vidaActual -= damage;
        Debug.Log(vidaActual);

    }
}

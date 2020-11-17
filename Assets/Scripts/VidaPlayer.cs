using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VidaPlayer : MonoBehaviour
{


    public int vidaActual;
    public bool checkPoint;
    public Vector3 respawn;
    

    // Start is called before the first frame update
    void Awake()
    {
        vidaActual = 10;
        checkPoint = false;
        respawn = transform.position;
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

    private void OnBecameInvisible()
    {
        vidaActual--;
        transform.position = respawn;
    }
}

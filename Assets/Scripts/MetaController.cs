using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaController : MonoBehaviour
{

    GameObject Carga2;
    // Start is called before the first frame update
    void Start()
    {
        Carga2 = GameObject.FindGameObjectWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("El jugador llego a la meta");
        Carga2.GetComponent<Level1Loader>().LoadLevel1();
    }
}

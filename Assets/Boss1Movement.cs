using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Movement : MonoBehaviour
{
    public GameObject Spawn1;
    public GameObject humo;
    public GameObject humoCheck;

    public GameObject humoGO;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mover(){


        

        humoGO = Instantiate(humo, humoCheck.transform.position, transform.rotation);
        Destroy(humoGO,1);

        this.transform.position = Spawn1.transform.position;
    }


  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlesMenu : MonoBehaviour
{
     [SerializeField] Text controles;
    // Start is called before the first frame update
    void Start()
    {
        
        controles.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            Debug.Log(controles.enabled);
            controles.enabled = true;
        }
        
        if(Input.GetKeyUp(KeyCode.C)){
            controles.enabled = false;
        }
    }
}

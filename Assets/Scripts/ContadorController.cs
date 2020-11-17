using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorController : MonoBehaviour
{

    public Text counterText;
    public GameObject player;
    
    float cronometro;
    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>() as Text;
        player = GameObject.Find("Player1");
    }

    // Update is called once per frame
    void Update()
    {   
        cronometro = player.GetComponent<colorController>().cronometro;
        
        counterText.text = cronometro.ToString("00");
    }
    private void FixedUpdate() {
        counterText.color = player.GetComponent<Renderer>().material.color;
    }
}

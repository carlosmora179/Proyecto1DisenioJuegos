using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 5;

    [SerializeField] GameObject player ;
    [SerializeField] GameObject orbe;
    [SerializeField] Renderer rend1;
    private Color color;
    
    void Start()
    {
        color = orbe.GetComponent<Orbe>().color;
        rend1.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Renderer>().material.color != color)
        {
            player.GetComponent<VidaPlayer>().TakeDamage(damage);
            player.GetComponent<VidaPlayer>().respawnPlayer();
        }
    }
}

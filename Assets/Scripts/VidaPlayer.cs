using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VidaPlayer : MonoBehaviour
{
    public bool checkPoint;
    public Vector3 respawn;

    public int maxHealth = 10;
    public int vidaActual ;
    
    public HealthBar healthBar;
    void Start() {
        checkPoint = false;
        respawn = transform.position;
        vidaActual = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaActual <= 0 ){

            
        }
    }
    public void TakeDamage(int damage){
        vidaActual -= damage;
        healthBar.SetHealth(vidaActual);
        

    }

    private void OnBecameInvisible()
    {
        TakeDamage(1);
        transform.position = respawn;
    }
}

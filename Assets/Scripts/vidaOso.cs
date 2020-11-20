using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaOso : MonoBehaviour
{


    public  int maxHealth = 100;
    int currentHealth;
    
     // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage){
        currentHealth -= damage;
        GetComponent<Boss1Movement>().Mover();
        if(currentHealth <=0){
            Die();
        }
    }
    void Die(){
        Debug.Log("Oso Morido");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
   
}

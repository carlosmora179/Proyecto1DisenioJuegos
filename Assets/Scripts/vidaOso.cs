using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaOso : MonoBehaviour
{


    public  int maxHealth = 100;
    int currentHealth;
    GameObject final;
    
     // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        final = GameObject.FindGameObjectWithTag("Finish");
    }
    public void TakeDamage(int damage){
        currentHealth -= damage;
        GetComponent<Boss1Movement>().Mover();
        if(currentHealth <=0){
            Die();
        }
    }
    void Die(){

        final.GetComponent<Level1Loader>().LoadLevel1();
        Destroy(GameObject.FindWithTag("Boss"));
        //GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
        
    }
   
}

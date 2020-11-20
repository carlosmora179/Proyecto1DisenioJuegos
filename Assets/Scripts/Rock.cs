using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    [Tooltip("Velocidad de movimiento en unidades del mundo")]
    public float speed;

    public int damage= 5;
    public float followTime = 0.2f;
    bool siguiendo = true;
    GameObject player;   
    Rigidbody2D rb2d;    
    Vector3 target, dir; 

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();

        // Recuperamos posición del jugador y la dirección normalizada
        
	}
    private void Update() {
        if(siguiendo){
            StartCoroutine(AutoAim(followTime));

            
        }
        
    }

    void FixedUpdate () {
        
        if (target != Vector3.zero) {
            rb2d.MovePosition(transform.position + (dir * speed) * Time.deltaTime);
        }
	}

    void OnTriggerEnter2D(Collider2D col){
        
        if (col.transform.tag == "Player" ){

            player.GetComponent<VidaPlayer>().TakeDamage(damage);
            Destroy(gameObject); 
        }
    }

    IEnumerator AutoAim(float seconds){

        if (player != null){
                target = player.transform.position;
                dir = (target - transform.position).normalized;
            
                 yield return new WaitForSeconds(seconds);
        }
        siguiendo = false;
        
    }

    void OnBecameInvisible() {
        
        Destroy(gameObject);
    }
}

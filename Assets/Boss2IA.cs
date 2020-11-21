using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2IA : MonoBehaviour
{
    public float visionAttackRadius,meleeRange;
    public GameObject player;
    Vector3 initialPosition, target;
    bool facingLeft = true;

    Animator anim;


    [Tooltip("Prefab de la roca que se disparará")]
    public GameObject firePrefab;
    [Tooltip("Velocidad de ataque (segundos entre ataques)")]
    public float attackSpeed = 2f;
    bool attacking,melee;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
        melee = false;
    }

    // Update is called once per frame
    void Update()
    {
        //
        target = initialPosition;

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position, 
            player.transform.position - transform.position, 
            visionAttackRadius, 
            1 << 8);

        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

        if (hit.collider != null) {
            if (hit.collider.tag == "Player"){
                target = player.transform.position;
            }
        }
       

        if(player.transform.position.x<transform.position.x && !facingLeft){
            
            facingLeft = true;
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            
        }
        if(player.transform.position.x>transform.position.x &&facingLeft){
            facingLeft = false;

            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            
            

        }

        float distance = Vector3.Distance(target, transform.position);
        
    
        if(target != initialPosition && distance < meleeRange){
            melee = true;
            anim.SetBool("Attack",false);
        }
        

        if (!melee && target != initialPosition && distance < visionAttackRadius){
            anim.SetBool("Attack",true);
            if (!attacking) StartCoroutine(Attack(attackSpeed));

            

        }
        //Debug.Log("Distancia> "+distance+ "rango> "+meleeRange);
        Debug.Log(melee);
        if(distance>visionAttackRadius){
            anim.SetBool("Attack",false);
        }
        else{
            melee = false;
            
        }
        
        Debug.DrawLine(transform.position, target, Color.green);
    }

    IEnumerator Attack(float seconds){
        attacking = true;  // Activamos la bandera
        // Si tenemos objetivo y el prefab es correcto creamos la roca
        if (target != initialPosition && firePrefab != null) {
            Instantiate(firePrefab, transform.position, transform.rotation);
            // Esperamos los segundos de turno antes de hacer otro ataque
            yield return new WaitForSeconds(seconds);
            
        }
        attacking = false; // Desactivamos la bandera
    }

     void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,visionAttackRadius);

        Gizmos.DrawWireSphere(transform.position,meleeRange);
    }


}


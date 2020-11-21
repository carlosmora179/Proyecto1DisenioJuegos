using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    
    public float attackRate= 1.5f;
    float nextAttackTime = 0f;

    void Update()
    {
        if(Time.time >= nextAttackTime){

            if(Input.GetMouseButtonDown(0)){
                Attack();
                Debug.Log("Attack");
                nextAttackTime = Time.time+1f / attackRate;
            } 
        }
       
    }


    public void Attack(){

        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("hit entitie " + enemy.name);

            enemy.GetComponent<vidaOso>().TakeDamage(attackDamage);
        }

    }
    void OnDrawGizmosSelected() {
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
        
    }
    
}

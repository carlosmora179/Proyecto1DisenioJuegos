using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovimientoPlayer : MonoBehaviour
{
    
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Camera mainCamera;

    bool facingRight = true;
    public float moveDirection = 0;

    public float dir; 
    public bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    Collider2D mainCollider;
    
    LayerMask layerMask = ~(1 << 2 | 1 << 8);
    Transform t;

    public bool playerState ;
    bool sameColor = false ;
    Color actualColor = Color.white;

    private Animator animplayer;
   
    void Start()
    {
        animplayer = GetComponent<Animator>();
        playerState = GetComponent<colorController>().pintado;
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<Collider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        gameObject.layer = 8;

        if(mainCamera)
            cameraPos = mainCamera.transform.position;
    }

    
    void Update()
    {

        playerState = GetComponent<colorController>().pintado;
        
        dir = r2d.velocity.x;

        if(moveDirection == 0 ){
            animplayer.SetBool("Run",false);
        }

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (isGrounded || r2d.velocity.x != 0.1f ) )
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
            
            animplayer.SetBool("Run",true);
            
            //Debug.Log("gire");
            
        }
        else
        {
            if (isGrounded || r2d.velocity.magnitude < 0.01f)
            {
                moveDirection = 0;
               
            } 
        }

        
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        
        if ((Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
        }

        if(mainCamera)
            mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
    }

    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, 0.1f, 0);
        layerMask = (playerState && sameColor) ? ~(1 << 2 | 1 << 8) : ~(1 << 2 | 1 << 8 | 1 << 9);
        
        isGrounded = Physics2D.OverlapCircle(groundCheckPos, 0.15f, layerMask);
        

        
        animplayer.SetBool("Grounded",isGrounded);
        
        

        
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);

    
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, 0.23f, 0), isGrounded ? Color.green : Color.red);
    }
     private void OnCollisionEnter2D(Collision2D colision) {
        
         try
         {
             actualColor = colision.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color;
         }
         catch (System.Exception)
         {
             
             //throw;
         }
             
         sameColor = (GetComponent<Renderer>().material.color == actualColor) ? true : false;
        
            
         
        
        
        
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class VidaPlayer : MonoBehaviour
{
    public bool checkPoint;
    public Vector3 respawn;
    private Transform m_cameraTransform;
    private CajaMovible[] plataformas;
    public int maxHealth = 10;
    public int vidaActual ;

    
    [Tooltip("controlador del mundor")]
    GameObject levelcontrol;
    
    public HealthBar healthBar;
    void Start() {
        checkPoint = false;
        respawn = transform.position;
        vidaActual = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        m_cameraTransform = Camera.main.transform;
        plataformas = FindObjectsOfType<CajaMovible>();
        levelcontrol = GameObject.FindGameObjectWithTag("GameController");
    }

    private void Update() {
        if(vidaActual <= 0){
            levelcontrol.GetComponent<LevelLoader>().GameOver();

        }
    }

    public void TakeDamage(int damage){
        vidaActual -= damage;
        healthBar.SetHealth(vidaActual);
        

    }

    private void OnBecameInvisible()
    {
        if(m_cameraTransform != null){
            if (m_cameraTransform.position.y > transform.position.y)
            {
                TakeDamage(1);
                respawnPlayer();
            }


        }
        
    }

    public void respawnPlayer()
    {
        foreach (CajaMovible platform in plataformas)
        {
            platform.Respawn();
        }
        transform.position = respawn;
    }
}

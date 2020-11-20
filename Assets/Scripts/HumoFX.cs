using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumoFX : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Fx(1f));
    }

  
  
  IEnumerator Fx(float seconds){
        
        yield return new WaitForSeconds(seconds);

        Destroy(this);
            
        
        
    }
}

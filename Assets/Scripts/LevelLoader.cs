using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
   public Animator transition;

   public GameObject canva;

   public float transitionTime = 1f;
    // Update is called once per frame
   private void Start() {
        StartCoroutine(loadInterface());
       
   }

    public void LoadNextLevel(){

        
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
         


    }
    IEnumerator LoadLevel(int levelIndex){
        //play
            transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transitionTime );

        //load Scene
        SceneManager.LoadScene(levelIndex);


    }

   IEnumerator loadInterface()
  {
       
       yield return new WaitForSeconds(transitionTime);
       canva.SetActive(true);
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTransition : MonoBehaviour {

    private Animator transitionAnim;
    
    private void Start()
    {
        transitionAnim = GetComponent<Animator>();
    }

    public void LoadScene(string sceneName) {
        
        StartCoroutine(Transition(sceneName));
    
    }


    IEnumerator Transition(string sceneName) {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(3);
        Debug.Log("Scene end");
        SceneManager.LoadScene(sceneName);
    }

}

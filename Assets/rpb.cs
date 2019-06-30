using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class rpb : MonoBehaviour
{
 public Transform LoadingBar;
 public Transform TextIndicator;
 public Transform TextLoading;
 [SerializeField] private float currentAmount;
 [SerializeField] private float speed;
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("devil")!=null){
        
        float x=GameObject.FindGameObjectWithTag("devil").GetComponent<Devil>().health;
        //if(currentAmount>0){
            currentAmount=x;
            TextIndicator.GetComponent<Text>().text=((int)currentAmount).ToString();
            TextLoading.gameObject.SetActive(true);
        
        LoadingBar.GetComponent<Image>().fillAmount=currentAmount/24;
    }
    else{
            TextIndicator.GetComponent<Text>().text="0";
            //TextIndicator.gameObject.SetActive(false);
            TextLoading.gameObject.GetComponent<Text>().text="Devil Killed";
        LoadingBar.GetComponent<Image>().fillAmount=0;
        //GameObject.FindGameObjectWithTag("radial").SetActive(false);
    }
}
}

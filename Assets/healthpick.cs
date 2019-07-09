using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpick : MonoBehaviour
{
    MyJoyStick playerScript;
    public int healamount;  
    public GameObject soundObject;
    private void Start(){
        //getting playerscirpt of PLayer object using get component and then later on calling Heal method in Playermovement script.
        playerScript=GameObject.FindGameObjectWithTag("Player").GetComponent<MyJoyStick>();

    }   
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag=="Player"){
            
            playerScript.Heal(healamount);
            
            Destroy(gameObject); //destroy healthpickup
            Instantiate(soundObject,transform.position,transform.rotation);       
        }
    }

    public void Update(){
        Destroy(this.gameObject,3);
       }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpick : MonoBehaviour
{
    PlayerMovement playerScript;
    public int healamount;  
    private void Start(){
        //getting playerscirpt of PLayer object using get component and then later on calling Heal method in Playermovement script.
        playerScript=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

    }   
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag=="Player"){
            
            
            playerScript.Heal(healamount);
            
            Destroy(gameObject); //destroy healthpickup       
        }
    }

    public void Update(){
        Destroy(this.gameObject,3);
       }
}

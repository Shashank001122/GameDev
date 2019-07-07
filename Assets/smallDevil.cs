using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallDevil : OurEnemy
{
    public float stopDistance;
    private float attackTime;
    public float attackSpeed;

    public void smallDevilHit(int damageAmount){
        health-=damageAmount;
                    if(health<=0){
                         Destroy(gameObject);
                    }
        }
    public void Start(){
        player=GameObject.FindGameObjectWithTag("smalldevilplayer").transform;
        smallPlayer=GameObject.FindGameObjectWithTag("smalldevilplayer").transform;
    }

    private void Update(){
        
        if(player!=null || smallPlayer!=null){
            if(Vector2.Distance(transform.position,player.position)>stopDistance){
                transform.position=Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
            }
            else{
                if(Time.time>=attackTime){
                    //attack 
                    StartCoroutine(Attack());
                    attackTime=Time.time+timeBetweenAttacks;
                }
            }
        }

    
    IEnumerator Attack(){

     player.GetComponent<PlayerMovement>().TakeDamage(damage);
     smallPlayer.GetComponent<PlayerMovement>().TakeDamage(damage);
     Vector2 originalPosition=transform.position;
     Vector2 targetPosition=player.position;

     float percent=0;
     while(percent<=1){
         percent+=Time.deltaTime*attackSpeed;
         float formula=(-Mathf.Pow(percent,2)+percent)*4;
         transform.position=Vector2.Lerp(originalPosition,targetPosition,formula);
         yield return null;   
     } 
    }    
    }
    
}
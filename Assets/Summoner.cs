using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : OurEnemy
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float attackSpeed;
    private Vector2 targetPosition;
    private Animator anim;
    public float stopDistance;
    public float attackTime;

    public float timeBetweenSummons;
    private float summonTime;
    public OurEnemy EnemyToSummon;

    public override void Start(){
        base.Start();//start function of our base class, ie, ourenemy class is called
        float randomX=Random.Range(minX,maxX);
        float randomY=Random.Range(minY,maxY);
        targetPosition=new Vector2(randomX,randomY);
        //Debug.Log(targetPosition);
        anim=GetComponent<Animator>();
    }

    private void Update(){  
        if(player!=null){
            if(Vector2.Distance(transform.position,targetPosition)> .5f){
                //Debug.Log("hi");
                transform.position=Vector2.MoveTowards(transform.position,targetPosition,speed*Time.deltaTime);
                anim.SetBool("ISRunning",true);
            }
            else{
                anim.SetBool("ISRunning",false);
                if (Time.time>=summonTime){
                    summonTime=Time.time+timeBetweenSummons;
                    anim.SetTrigger("summon");
                }
            }
            if(Vector2.Distance(transform.position,player.position)<stopDistance){
                if(Time.time>attackTime){
                    //attack 
                    StartCoroutine(Attack());
                    attackTime=Time.time+timeBetweenAttacks;
                }
            }
        }
    }

    public void Summon(){
        if(player!=null){
            Instantiate(EnemyToSummon,transform.position,transform.rotation);
        }
    }
    IEnumerator Attack(){
     player.GetComponent<MyJoyStick>().TakeDamage(damage);
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

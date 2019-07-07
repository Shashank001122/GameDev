using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallplayer : MonoBehaviour
{
    public float stopDistance;
    private float attackTime;
    private Animator anim;
    public int health;
    public Transform shotPoint;
    public GameObject EnemyBullet;
    public GameObject bossplayer;
    public int speed;
    public GameObject finalWeapon;
    public int timeBetweenAttacks;
    public GameObject bloodsplash;
    
    public void Start(){
        bossplayer=GameObject.FindGameObjectWithTag("devil");
        anim=GetComponent<Animator>();
    }
    private void Update()
    {
        if(bossplayer!=null){
            //Debug.Log(player);
        if(Vector2.Distance(transform.position,bossplayer.transform.position)>stopDistance){
            transform.position=Vector2.MoveTowards(transform.position,bossplayer.transform.position,speed*Time.deltaTime);
        }
        if(Vector2.Distance(transform.position,bossplayer.transform.position)<stopDistance){
            transform.position=Vector2.MoveTowards(transform.position,bossplayer.transform.position,-1*speed*Time.deltaTime);
        }  

              /*
        if(gameObject==null){
        Instantiate(bloodsplash,transform.position,transform.rotation);
        }
        */
        }
        
    }
    

    public void RangedAttack(){
        if(bossplayer!=null){
        Vector2 direction=bossplayer.transform.position-shotPoint.position; 
        float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        Quaternion rotation =Quaternion.AngleAxis(angle-90,Vector3.forward);
        shotPoint.rotation=rotation;
        finalWeapon.transform.rotation=rotation;
        Instantiate(EnemyBullet,shotPoint.position,shotPoint.rotation);
    }
    }
}



/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallPlayer: MonoBehaviour
{
    // Start is called before the first frame update
    public float stopDistance;
    private float attackTime;
    private Animator anim;
    public Transform shotPoint;
    public GameObject EnemyBullet;
    public GameObject bossplayer;
    public void Start(){
        //base.Start();
        bossplayer=GameObject.FindGameObjectWithTag("devil");
        anim=GetComponent<Animator>();
    }
    // Update is called once per frame
    private void Update()
    {
        if(bossplayer!=null){
            //Debug.Log(player);
        if(Vector2.Distance(transform.position,player.position)>stopDistance){
            transform.position=Vector2.MoveTowards(transform.position,bossplayer.position,speed*Time.deltaTime);
        }
        if(Time.time>=attackTime){
            attackTime=Time.time+timeBetweenAttacks;
            anim.SetTrigger("attack");
        }
    }
    }
    public void RangedAttack(){
        if(player!=null){
        Vector2 direction=bossplayer.position-shotPoint.position; 
        float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        Quaternion rotation =Quaternion.AngleAxis(angle-90,Vector3.forward);
        shotPoint.rotation=rotation;
        Instantiate(gameObject,shotPoint.position,shotPoint.rotation);
    }
    }
}*/

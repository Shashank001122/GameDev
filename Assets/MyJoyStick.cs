﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityStandardAssets.CrossPlatformInput;
public class MyJoyStick : MonoBehaviour
{
   public float speed;
   private Rigidbody2D rb;
   private Vector2 moveAmount;//how much we are going to move..
   private Animator anim; 
   public int health;

   public Image[] hearts;
   public Sprite fullHeart;
   public Sprite emptyHeart;
   WaveSpawnner WaveSpawnnerScript;
    public int wavenumber;
    public Joystick joystick;
    //public float moveForce=1000f;
    public bool check;
    public Animator hurtAnim;
    public GameObject soundObject;
    public Scene scene;
    private void Start(){
       anim=GetComponent<Animator>();
       rb=GetComponent<Rigidbody2D>();
        scene = SceneManager.GetActiveScene();
       joystick=GameObject.FindObjectOfType<Joystick>();          
    }
  
    private void Update(){
        //rb.velocity=new Vector2(joystick.Horizontal*speed,joystick.Vertical*speed);    
        Vector2 moveInput=new Vector2(joystick.Horizontal,joystick.Vertical);
        moveAmount=moveInput*speed;

        if (moveInput!=Vector2.zero){ //chahracter is running
            anim.SetBool("ISRunning",true);
            check=true;
        }
        else{
            anim.SetBool("ISRunning",false);
            check=false; 
        }
    }

   private void FixedUpdate(){ //any code related to physics goes inside this function
       rb.MovePosition(rb.position + moveAmount*Time.fixedDeltaTime);
    }
/* 
    public void TakeDamage(int damageAmount){
        health-=damageAmount;
        UpdateHealthUI(health);
        hurtAnim.SetTrigger("hurt");
        if (health<=0){
            Destroy(gameObject);
            screenTransition.LoadScene("Lose");
        }
    }
*/
public void TakeDamage(int damageAmount){
        
        health-=damageAmount;
        UpdateHealthUI(health);
        hurtAnim.SetTrigger("hurt");
        if (health<=0){
            //GameObject smallplayer=GameObject.FindGameObjectWithTag("smalldevilplayer");
            //Instantiate(smallplayer.GetComponent<smallplayer>().bloodsplash,smallplayer.transform.position,smallplayer.transform.rotation);
            //Destroy(smallplayer);
            Destroy(gameObject);
            
            //Instantiate(soundObject,transform.position,transform.rotation);
            ScreenTransition screenTransition=GameObject.FindGameObjectWithTag("transitionpanel").GetComponent<ScreenTransition>();
              if(scene.name=="Level2"){
                            screenTransition.LoadScene("Lose2");
                        }
                        else{
                            screenTransition.LoadScene("Lose");
                        }
           // screenTransition.LoadScene("Lose");   
        }
        }
    //////////Change weapon is called///////////
    public void ChangeWeapon(Weapon WeaponToEquip){
        
    GameObject playerObject=GameObject.FindGameObjectWithTag("Player");
    int i = 0;

    //Array to hold all child obj
    GameObject[] allChildren = new GameObject[playerObject.transform.childCount];

    //Find all child obj and store to that array
    foreach (GameObject child in allChildren)
    {
        if((child.transform.name != "healthbar")  && (child.transform.name != "body") && (child.transform.name != "leg left") && (child.transform.name != "leg right"))
            Destroy(child.gameObject);
    }

    //Now destroy them
    foreach (GameObject child in allChildren)
    {
        Destroy(child.gameObject);
    }
        Instantiate(WeaponToEquip,transform.position,transform.rotation,transform);
    } 

    void UpdateHealthUI(int currentHealth){
        if(scene.name=="SampleScene"){
        
        for(int i=0;i<8;i++){
            if(i<currentHealth){
                hearts[i].sprite=fullHeart;
            }    
            else{
                hearts[i].sprite=emptyHeart;
            }

        }
        }
        else{
         for(int i=0;i<10;i++){
            if(i<currentHealth){
                hearts[i].sprite=fullHeart;
            }    
            else{
                hearts[i].sprite=emptyHeart;
            }

        }
        }   
        
    }


    public void Heal(int healamount){
        if(scene.name=="SampleScene"){
        if(health+healamount>8){
            health=8;
        }
        else{
            health=health+healamount;
        }
        UpdateHealthUI(health);
        
    }
    
    else{
        if(health+healamount>10){
            health=10;
        }
        else{
            health=health+healamount;
        }
        UpdateHealthUI(health);
        
    }
    }
}
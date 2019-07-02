using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{   
    public Weapon WeaponToEquip;
    WaveSpawnner WaveSpawnnerScript;
    public int wavenumber;
    
     public GameObject explosion;
     public float Timer = 5.0f;
     public GameObject soundObject;
     public void DestroyProjectile(){
        //Destroy(gameObject);
        Instantiate(explosion,transform.position,Quaternion.identity);
        
    }

    //gameobject is out pickup collides with player..
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag =="Player"){    
            //Stats.Life -=1;
           // print("collided");
            if(gameObject.transform.name=="Barrel(Clone)"){
                //print(gameObject.transform.name);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(collision.gameObject.transform.position,10.0f);
            Debug.Log(colliders);
            foreach (Collider2D col in colliders)
            {
                if (col.tag == "Enemy")
                {
                //Debug.Log(col.transform.name);    
                Destroy(col.gameObject);
                }
            }
            Destroy(gameObject);
            DestroyProjectile();
            }
            else{
            collision.GetComponent<PlayerMovement>().ChangeWeapon(WeaponToEquip);
            Destroy(gameObject);//destory pickup  
            Instantiate(soundObject,transform.position,transform.rotation);  
            }
        }        
        }
    public void Update(){
        if(this.gameObject.transform.name!="Barrel(Clone)"){
        Destroy(this.gameObject,3);
       }
       else{
           Destroy(this.gameObject,3f);
       }
       
    }
}
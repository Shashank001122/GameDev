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
     public void DestroyProjectile(){
        //Destroy(gameObject);
        Instantiate(explosion,transform.position,Quaternion.identity);
        
    }

    //gameobject is out pickup collides with player..
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag =="Player"){    
            
            collision.GetComponent<PlayerMovement>().ChangeWeapon(WeaponToEquip);
            Destroy(gameObject);//destory pickup  
              
            }
        }        
        
    public void Update(){
        /*
        if(this.gameObject.transform.name!="Barrel(Clone)"){*/
        Destroy(this.gameObject,3);
       /*
       }
       else{
           Destroy(this.gameObject,4f);
       }
       */
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{   
    public Weapon WeaponToEquip;
    WaveSpawnner WaveSpawnnerScript;
    public int wavenumber;
    
     public float Timer = 5.0f;
     public GameObject soundObject;

     public GameObject typeofprojectile;
     
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag =="Player"){               
            if(gameObject.transform.name=="pickup_5(Clone)"){
            WeaponToEquip.projectile=gameObject.GetComponent<Pickup>().typeofprojectile;
            collision.GetComponent<PlayerMovement>().ChangeWeapon(WeaponToEquip);
            
            Destroy(gameObject);
            //DestroyProjectile();
            }
            else{
                Debug.Log("Entered");
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
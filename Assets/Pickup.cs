using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{   
    public Weapon WeaponToEquip;
    WaveSpawnner WaveSpawnnerScript;
    public int wavenumber;
    //public List<GameObject> myList = new List<GameObject>();
    
    //gameobject is out pickup collides with player..
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag=="Player"){    
            
            collision.GetComponent<PlayerMovement>().ChangeWeapon(WeaponToEquip);
            Destroy(gameObject);//destory pickup    
        }        
    }
    public void Update(){
        Destroy(this.gameObject,3);
       }
}
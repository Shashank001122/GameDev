using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public GameObject explosion;
    public int damage;
       WaveSpawnner WaveSpawnnerScript;
    public int wavenumber;
    

    private void Start(){
        //Destroy(gameObject,lifeTime);//if the lieftime is passed we destroy the projecticle..
        Invoke("DestroyProjectile",lifeTime);
        
    }

    private void Update(){
        transform.Translate(Vector2.up*speed*Time.deltaTime); 
    }  


    public void DestroyProjectile(){
        Destroy(gameObject);
        Instantiate(explosion,transform.position,Quaternion.identity);
        
    }

 
    //to detect collision..with enemy
    private void OnTriggerEnter2D(Collider2D collision){
        
        if (collision.tag =="Enemy" && GameObject.FindGameObjectWithTag("Player") != null){
            
            //Changes being made
            WaveSpawnnerScript=GameObject.FindGameObjectWithTag("wave").GetComponent<WaveSpawnner>();
            wavenumber=WaveSpawnnerScript.currentWaveIndex;
            
            if(wavenumber>=1){
                    if(collision.GetComponent<OurEnemy>().transform.name=="Sphere(Clone)"
                        && GameObject.FindGameObjectWithTag("Weapon").transform.name!="gun"
                        )
                    {        
                        //damage=1;
                        collision.GetComponent<OurEnemy>().YellowBoost(damage);
                        DestroyProjectile();
                    }   
                
                else{
                
                collision.GetComponent<OurEnemy>().TakeDamage(damage); //collision.GetComponent<Enemy> loads the enemy script on
                                                        //collision object and call the TakeDamage function of Enemy.cs
                DestroyProjectile();
                  
                }
                
            }
            else{   
                
                collision.GetComponent<OurEnemy>().TakeDamage(damage); //collision.GetComponent<Enemy> loads the enemy script on
                                                    //collision object and call the TakeDamage function of Enemy.cs
            DestroyProjectile();
            }
        }
        if(collision.tag=="devil"){
        collision.GetComponent<Devil>().TakeDamage(damage);
            DestroyProjectile();
        }

    }
}

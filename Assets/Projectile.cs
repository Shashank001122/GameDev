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
    public GameObject prefab;
    public int Devilscripthealth;
    private ScreenTransition screenTransition;
    public GameObject soundObject;

    private void Start(){
        Invoke("DestroyProjectile",lifeTime);
        screenTransition=FindObjectOfType<ScreenTransition>();
        Instantiate(soundObject,transform.position,transform.rotation);
    } 

    private void Update(){
        transform.Translate(Vector2.up*speed*Time.deltaTime); 
        //Destroy(this.gameObject,3);
    }  
    public void DestroyProjectile(){
        Destroy(gameObject);
        Instantiate(explosion,transform.position,Quaternion.identity);       
    }
  
    IEnumerator Order()
    {
   yield return new WaitForSeconds (3.0f);  
    }

    //to detect collision..with enemy
    private void OnTriggerEnter2D(Collider2D collision){
        
        if (collision.tag =="Enemy" && GameObject.FindGameObjectWithTag("Player")!= null){
            
            //Changes being made
            WaveSpawnnerScript=GameObject.FindGameObjectWithTag("wave").GetComponent<WaveSpawnner>();
            wavenumber=WaveSpawnnerScript.currentWaveIndex;

            if(collision.GetComponent<OurEnemy>().transform.name=="smallDevil(Clone)" && GameObject.FindGameObjectWithTag("Player")!= null ){
                 
                 if(GameObject.FindGameObjectWithTag("devil")==null){
                    if(GameObject.FindGameObjectsWithTag("Enemy").Length!=0){
                         
                        GameObject[] allsmalldevils=GameObject.FindGameObjectsWithTag("Enemy");
                        foreach (GameObject child in allsmalldevils)
                        {
                            child.GetComponent<OurEnemy>().smallDevilHit(damage,collision,gameObject);
                            
                        }
                        DestroyProjectile();
                        StartCoroutine(Order());
                        screenTransition.LoadScene("Win");
                        }
                    else{
                        StartCoroutine(Order());
                        screenTransition.LoadScene("Win");
                    }
                 }
                    else{
                        collision.GetComponent<OurEnemy>().smallDevilHit(damage,collision,gameObject); 
                        DestroyProjectile();
                    }
                }
                
            /* 
             collision.GetComponent<OurEnemy>().smallDevilHit(damage,collision,gameObject);
             if(GameObject.FindGameObjectWithTag("devil")==null){
                    if(GameObject.FindGameObjectsWithTag("Enemy").Length==0){   
                        
                        StartCoroutine(Order());
                        screenTransition.LoadScene("Win");
                    }
                 }
                    else{
                        collision.GetComponent<OurEnemy>().smallDevilHit(damage,collision,gameObject); 
                        DestroyProjectile();
                    }
                }*/
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
                if(!(collision.GetComponent<OurEnemy>().transform.name=="smallDevil(Clone)" && GameObject.FindGameObjectWithTag("Player")!= null)){            
                collision.GetComponent<OurEnemy>().TakeDamage(damage); //collision.GetComponent<Enemy> loads the enemy script on
                                                    //collision object and call the TakeDamage function of Enemy.cs
            DestroyProjectile();
            }
            }
        }
        if(collision.tag=="devil" && GameObject.FindGameObjectWithTag("Player")!= null){
            collision.GetComponent<Devil>().TakeDamage(damage);
            prefab = (GameObject)Resources.Load("ToonExplosion/Prefabs/smallDevil", typeof(GameObject));
            Instantiate(prefab,transform.position,Quaternion.identity);
            DestroyProjectile();
            }

        if(collision.tag=="bomb" && GameObject.FindGameObjectWithTag("Player")!= null){
                explosion = (GameObject)Resources.Load("ToonExplosion/Prefabs/Explosion", typeof(GameObject)); 
                Collider2D[] colliders = Physics2D.OverlapCircleAll(collision.gameObject.transform.position,4.0f);
                foreach (Collider2D col in colliders)
                {
                    if (col.tag == "Enemy")
                    {
                    Destroy(col.gameObject);
                    }
                }
                Destroy(collision.gameObject);
                Instantiate(explosion,transform.position,Quaternion.identity);
        }
            
        }   
}



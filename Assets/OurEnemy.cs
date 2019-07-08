using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global{
    public static int count=0;
}
public class OurEnemy : MonoBehaviour
{
    public int health;
    GameObject temp_weapon;

    [HideInInspector]
    public Transform player;
    public Transform smallPlayer;

    [SerializeField]
    private GameObject go;

    public float speed;
    public float timeBetweenAttacks;
    public int damage;

    public int pickUpChance;
    
    public GameObject[] pickups;
    public GameObject randomPickup;
    public GameObject mainweapon;
    public int ind;
    public int index;
    public int healthPickupChance;
    public GameObject healthPickup;
    PlayerMovement playerScript;   
    public int playerHealth; 
    public bool check;
    public int count;
    public GameObject soundObject;
     WaveSpawnner WaveSpawnnerScript;
    public int wavenumber;
    public GameObject prefab;
    public Vector2 positionEnemyDie;
    public GameObject bloodsplash;

        public virtual void Start(){
        player=GameObject.FindGameObjectWithTag("Player").transform;
        
        //StartCoRoutine(Scale());
    }

    public float scalingFactor = 5.0f;
 
    IEnumerator Scale(float time)//4 second tak code chalega, har frame k liye dheere deehre bada hoga
                                    //, coz of while loop
    //public void Update ()
     {        
        float currentTime = 0.0f;
         Vector3 originalScale = gameObject.transform.localScale;
         Vector3 destinationScale = new Vector3(2.5f, 2.5f, 2.5f);
         while(currentTime<time){
         gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime /
            time);
             currentTime += Time.deltaTime;
             yield return null;
         }
     }  


    IEnumerator Order()
    {
   yield return new WaitForSeconds (3.0f);  
    }

    public void smallDevilHit(int damageAmount, Collider2D collision, GameObject proj){
        health-=damageAmount;
        GameObject mainweapon=GameObject.FindGameObjectWithTag("Weapon");
        Debug.Log(proj);
        
        if(health<=0 && mainweapon.transform.name!="finalweapon(Clone)"){
                temp_weapon=mainweapon;
                Instantiate(soundObject,transform.position,transform.rotation);
                int randomNumber=Random.Range(0,101);
                if (randomNumber<pickUpChance){ 
                pickups[0].transform.position=(GameObject.FindGameObjectWithTag("Player").transform.position+this.gameObject.transform.position)/2;
                

            if(proj.transform.name=="flames(Clone)"){
            GameObject prefab1 = (GameObject)Resources.Load("ToonExplosion/Prefabs/flamee_1", typeof(GameObject));
            
            pickups[0].GetComponent<Pickup>().typeofprojectile=prefab1;
            }
                
                 if(proj.transform.name=="w1_projections(Clone)"){
            GameObject prefab1 = (GameObject)Resources.Load("ToonExplosion/Prefabs/w1_projections_1", typeof(GameObject));
            pickups[0].GetComponent<Pickup>().typeofprojectile=prefab1;
            }
            
            if(proj.transform.name=="w2_projection(Clone)"){
            GameObject prefab1 = (GameObject)Resources.Load("ToonExplosion/Prefabs/w2_projection_2", typeof(GameObject));
            pickups[0].GetComponent<Pickup>().typeofprojectile=prefab1;
            }

            if(proj.transform.name=="w3_projection(Clone)"){
            GameObject prefab1 = (GameObject)Resources.Load("ToonExplosion/Prefabs/w3_projection_3", typeof(GameObject));
            pickups[0].GetComponent<Pickup>().typeofprojectile=prefab1;
            }
                
                Instantiate(pickups[0],pickups[0].transform.position+new Vector3(10.0f,10.0f,0.0f),pickups[0].transform.rotation);
                Global.count=1;
                }
            Destroy(gameObject);    
        }

        if(health<=0 && mainweapon.transform.name=="finalweapon(Clone)" && Global.count==1){    
            Vector2 pos=collision.transform.position;
            Quaternion rot=collision.transform.rotation;    
            Instantiate(bloodsplash,transform.position,transform.rotation);
            StartCoroutine(Order());
            prefab.transform.position=pos;
            //prefab.GetComponent<smallplayer>().EnemyBullet=proj;  
            //Debug.Log(prefab.GetComponent<smallplayer>().EnemyBullet);
            Instantiate(prefab,prefab.transform.position,prefab.transform.rotation);
            Instantiate(soundObject,transform.position,transform.rotation);
            //GameObject smallPlayer=GameObject.FindGameObjectWithTag("smalldevilplayer");
            Global.count=2;
            Destroy(gameObject);
        }
        if(health<=0 && mainweapon.transform.name=="finalweapon(Clone)" && Global.count==2){
                Instantiate(soundObject,transform.position,transform.rotation);
                Destroy(gameObject);    
        }
    }   
    

    public void YellowBoost(int boostAmount){
           WaveSpawnnerScript=GameObject.FindGameObjectWithTag("wave").GetComponent<WaveSpawnner>();
                wavenumber=WaveSpawnnerScript.currentWaveIndex;
            
            if(wavenumber>=1){
                int randomNumber=Random.Range(0,100);
                if (randomNumber<pickUpChance){ 
                if(GameObject.FindGameObjectWithTag("Weapon").transform.name !="gun(Clone)"){
                    pickups[1].transform.position=(GameObject.FindGameObjectWithTag("Player").transform.position+this.gameObject.transform.position)/2;    
    
                    Instantiate(pickups[1],pickups[1].transform.position,transform.rotation);
                    
                    StartCoroutine(Scale(4.0f));
                }
            }
            }
            if(GameObject.FindGameObjectWithTag("Weapon").transform.name =="gun(Clone)"){
                    health-=boostAmount;
                    if(health<=0){
                         Destroy(gameObject);
                         //orange wala prefab
                          Instantiate(soundObject,transform.position,transform.rotation);
                    }
        }
    } 
    
    public void TakeDamage(int damageAmount){
        if(GameObject.FindGameObjectWithTag("Player")){
        health-=damageAmount;
        
        mainweapon=GameObject.FindGameObjectWithTag("Weapon");
        if (health<=0){
                WaveSpawnnerScript=GameObject.FindGameObjectWithTag("wave").GetComponent<WaveSpawnner>();
                wavenumber=WaveSpawnnerScript.currentWaveIndex;
                index=0;
                    if(wavenumber==0){
                        if(mainweapon.transform.name=="gun"){
        
                            Destroy(gameObject);
                            Instantiate(soundObject,transform.position,transform.rotation);
                   }
                }                       
            if(wavenumber>=1 && gameObject.transform.name!="smallDevil(Clone)"){    
            int randomNumber=Random.Range(0,101);
            if (randomNumber<pickUpChance){  
                if((wavenumber==1 && mainweapon.transform.name=="gun(Clone)") || 
                (wavenumber==1 && mainweapon.transform.name=="gun"))
                {    
                pickups[0].transform.position=(GameObject.FindGameObjectWithTag("Player").transform.position+this.gameObject.transform.position)/2;
                Instantiate(pickups[0],pickups[0].transform.position,transform.rotation);//gameObject.instantiate     
                }

                 else{
                 
                 char name=mainweapon.transform.name[7];
                 ind=System.Convert.ToInt32(name);//1 or 2

                if(ind==49){//pink rocket now, pick arrow or bow
                    
                    if(gameObject.transform.name!="Sphere(Clone)"){
                        randomPickup=pickups[Random.Range(1,pickups.Length-1)];
                        
                    randomPickup.transform.position=(GameObject.FindGameObjectWithTag("Player").transform.position+this.gameObject.transform.position)/2;
                        
                        Instantiate(randomPickup,randomPickup.transform.position,transform.rotation);
                    }
                
                }
                if(ind==50){//arrow now, pick bow
                    randomPickup=pickups[2];
                    randomPickup.transform.position=(GameObject.FindGameObjectWithTag("Player").transform.position+this.gameObject.transform.position)/2;
                    Instantiate(randomPickup,transform.position,transform.rotation);
                }                            
        }
            }
    int randHealth=Random.Range(0,101);
    playerScript=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    playerHealth=playerScript.health;
    if(randHealth<healthPickupChance){
        if(playerHealth<6){
        healthPickup.transform.position=this.gameObject.transform.position+new Vector3(6f,1f,0f);
        Instantiate(healthPickup,transform.position,transform.rotation);
    }
    }
    
    Destroy(gameObject);
    Instantiate(soundObject,transform.position,transform.rotation);
    }
    }
}
}
}

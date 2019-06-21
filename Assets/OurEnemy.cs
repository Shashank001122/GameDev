using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurEnemy : MonoBehaviour
{
    public int health;

    [HideInInspector]
    public Transform player;

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
     WaveSpawnner WaveSpawnnerScript;
    public int wavenumber;

        public virtual void Start(){
        player=GameObject.FindGameObjectWithTag("Player").transform;
        //StartCoRoutine(Scale());
    }

    public float scalingFactor = 5.0f;
 
    IEnumerator Scale(float time)
    //public void Update ()
     {        
        float currentTime = 0.0f;
         Vector3 originalScale = gameObject.transform.localScale;
         Vector3 destinationScale = new Vector3(2.0f, 2.0f, 2.0f);
         
         while(currentTime<time){
         gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime /
            time);
             currentTime += Time.deltaTime;
             yield return null;
         }
         //yield return new WaitForSeconds(4.0f);
     
     }
    /*
    IEnumerator Scale()
     {
         //Vector3 originalScale = gameObject.transform.localScale;
         //Vector3 destinationScale = new Vector3(2.0f, 2.0f, 2.0f);
         
         //float currentTime = 0.0f;
         gameObject.transform.localScale+=new Vector3(2.0f, 2.0f, 2.0f);
         yield return new WaitForSeconds(2.0f);
         /*
        
         {
            gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime /
            time);
             currentTime += Time.deltaTime;
             yield return null;
         } while (currentTime <= time);
         
        // Destroy(gameObject);
     }
    */
    public void YellowBoost(int boostAmount){

           WaveSpawnnerScript=GameObject.FindGameObjectWithTag("wave").GetComponent<WaveSpawnner>();
                wavenumber=WaveSpawnnerScript.currentWaveIndex;
            
            if(wavenumber>=1){
                int randomNumber=Random.Range(0,100);
                if (randomNumber<pickUpChance){ 
                if(GameObject.FindGameObjectWithTag("Weapon").transform.name !="gun(Clone)"){
                    pickups[1].transform.position=this.gameObject.transform.position+new Vector3(1.5f,1.5f,0f);    
                    //gameObject.pickUpChance=60;
                    Instantiate(pickups[1],pickups[1].transform.position,transform.rotation);
                    //Debug.Log(pickups[1]);
                    StartCoroutine(Scale(4.0f));
                }
            }
            }
            if(GameObject.FindGameObjectWithTag("Weapon").transform.name =="gun(Clone)"){
                    health-=boostAmount;
                    if(health<=0){
                         Destroy(gameObject);
                    }
        }
    } 
    
    public void TakeDamage(int damageAmount){
        if(GameObject.FindGameObjectWithTag("Player")){
        health-=damageAmount;
        //Debug.Log("Health"+gameObject.health);
        mainweapon=GameObject.FindGameObjectWithTag("Weapon");
        if (health<=0){
                WaveSpawnnerScript=GameObject.FindGameObjectWithTag("wave").GetComponent<WaveSpawnner>();
                wavenumber=WaveSpawnnerScript.currentWaveIndex;
                index=0;
                
                    if(wavenumber==0){
                        if(mainweapon.transform.name=="gun"){
                            //Debug.Log("hit");
                            Destroy(gameObject);
                            
                        }
                }   
                    
            if(wavenumber>=1){
            //if(WaveSpawnnerScript.countEnemy==1){    
                
            int randomNumber=Random.Range(0,101);
            if (randomNumber<pickUpChance){  
               
                if((wavenumber==1 && mainweapon.transform.name=="gun(Clone)") || 
                (wavenumber==1 && mainweapon.transform.name=="gun"))
                {    
                Instantiate(pickups[0],transform.position,transform.rotation);//gameObject.instantiate    
                //Debug.Log(mainweapon.transform.name);
                }

                 else{
                 Debug.Log("error"+mainweapon);    
                 char name=mainweapon.transform.name[7];
                 ind=System.Convert.ToInt32(name);//1 or 2

                if(ind==49){//pink rocket now, pick arrow or bow
                    
                    if(gameObject.transform.name!="Sphere(Clone)"){
                        randomPickup=pickups[Random.Range(1,pickups.Length-1)];
                        randomPickup.transform.position=this.gameObject.transform.position+new Vector3(7f,1f,0f);
                        
                        Instantiate(randomPickup,transform.position,transform.rotation);
                    }
                
                }
                if(ind==50){//arrow now, pick bow
                    randomPickup=pickups[2];
                    randomPickup.transform.position=this.gameObject.transform.position+new Vector3(7f,1f,0f);
                    Instantiate(randomPickup,transform.position,transform.rotation);
                }
                                                    
            //}          
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

    }
        }
}
}
}
/* 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurEnemy : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update

    [HideInInspector]
    public Transform player;

    public float speed;
    public float timeBetweenAttacks;
    public int damage;

    public int pickUpChance;
    public GameObject[] pickups;
    public GameObject last;
    
    public virtual void Start(){
        player=GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int damageAmount){
        health-=damageAmount;
        if (health<=0){
            
            int randomNumber=Random.Range(0,101);
            if (randomNumber<pickUpChance){
                 GameObject randomPickup=pickups[Random.Range(0,pickups.Length)];
                 //if(last!=randomPickup){
                 Instantiate(randomPickup,transform.position,transform.rotation);
                 //last=randomPickup; 
                   
                 //}
            }
            Destroy(gameObject);
        }
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurEnemy : MonoBehaviour
{
    public int health;

    [HideInInspector]
    public Transform player;

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

     WaveSpawnner WaveSpawnnerScript;
    public int wavenumber;
    
    //public List<GameObject> meshGOB;
    public virtual void Start(){
        player=GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void YellowBoost(int boostAmount){
           WaveSpawnnerScript=GameObject.FindGameObjectWithTag("wave").GetComponent<WaveSpawnner>();
                wavenumber=WaveSpawnnerScript.currentWaveIndex;
            
            if(wavenumber>=1 && GameObject.FindGameObjectWithTag("Weapon").transform.name!="gun(Clone)" ){
                    
                gameObject.transform.localScale+=new Vector3(1f,1f,1f);        
                
                int randomNumber=Random.Range(0,90);
                if (randomNumber<pickUpChance){
                    pickups[1].transform.position=gameObject.transform.position+new Vector3(3f,3f,0f);    
                    Instantiate(pickups[1],pickups[1].transform.position,transform.rotation);
                    Debug.Log(boostAmount);   
                }                
            }
        
            if(GameObject.FindGameObjectWithTag("Weapon").transform.name =="gun(Clone)"){
                health-=boostAmount;
                if(health<=0){
                Destroy(gameObject);
                }              
            }
    }
     
    public void TakeDamage(int damageAmount){
    
        health-=damageAmount;
        if (health<=0){
            int randomNumber=Random.Range(0,101);
            if (randomNumber<pickUpChance){
            
            index=0;
                mainweapon=GameObject.FindGameObjectWithTag("Weapon");
                if(mainweapon.transform.name=="gun" && check!=true){
                 Instantiate(pickups[index],transform.position,transform.rotation);//gameObject.instantiate    
                }
                 else{
                 char name=mainweapon.transform.name[7];
                 ind=System.Convert.ToInt32(name);//1 or 2

                if(ind==49){//pink rocket now, pick arrow or bow
                    
                    if(gameObject.transform.name!="Sphere(Clone)"){
                        randomPickup=pickups[Random.Range(1,pickups.Length-1)];
                        Instantiate(randomPickup,transform.position,transform.rotation);
                    }
                
                }
                if(ind==50){//arrow now, pick bow
                    randomPickup=pickups[2];
                    Instantiate(randomPickup,transform.position,transform.rotation);
                }
                                                    
            }          
        }
    int randHealth=Random.Range(0,101);
    playerScript=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    playerHealth=playerScript.health;
    if(randHealth<healthPickupChance){
        if(playerHealth<6){
        Instantiate(healthPickup,transform.position,transform.rotation);
    }
    }
     Destroy(gameObject);

    }

}
}
*/
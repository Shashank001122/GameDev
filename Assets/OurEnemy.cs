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

    private ScreenTransition screenTransition;

        public virtual void Start(){
        player=GameObject.FindGameObjectWithTag("Player").transform;
        screenTransition=FindObjectOfType<ScreenTransition>();
        //StartCoRoutine(Scale());
    }

    public float scalingFactor = 5.0f;
 
    IEnumerator Scale(float time)//4 second tak code chalega, har frame k liye dheere deehre bada hoga
                                    //, coz of while loop
    //public void Update ()
     {        
        float currentTime = 0.0f;
         Vector3 originalScale = gameObject.transform.localScale;
         Vector3 destinationScale = new Vector3(2.0f, 2.0f, 2.0f);
         
         while(currentTime<time){
         gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime /
            time);
             currentTime += Time.deltaTime;
             //Debug.Log(currentTime);
             yield return null;
             //yield return new WaitForSeconds(1.0f);
         }
         
     
     }

    public void smallDevilHit(int damageAmount){
        health-=damageAmount;
                    if(health<=0){
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
                    //pickups[1].transform.position=GameObject.FindGameObjectWithTag("Player").transform.position+0.3f*
                    //(this.gameObject.transform.position-GameObject.FindGameObjectWithTag("Player").transform.position)/2;    
                    Instantiate(pickups[1],pickups[1].transform.position,transform.rotation);
                    
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
                pickups[0].transform.position=(GameObject.FindGameObjectWithTag("Player").transform.position+this.gameObject.transform.position)/2;
                Instantiate(pickups[0],pickups[0].transform.position,transform.rotation);//gameObject.instantiate     
                }

                 else{
                 
                 char name=mainweapon.transform.name[7];
                 ind=System.Convert.ToInt32(name);//1 or 2

                if(ind==49){//pink rocket now, pick arrow or bow
                    
                    if(gameObject.transform.name!="Sphere(Clone)"){
                        randomPickup=pickups[Random.Range(1,pickups.Length-1)];
                        //randomPickup.transform.position=this.gameObject.transform.position+new Vector3(2f,2f,0f);
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

    }
        }
}
}
}

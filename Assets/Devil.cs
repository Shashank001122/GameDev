using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Devil : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public OurEnemy[] enemies;
    public float spawnOffset;
    public int damage;
    private int halfHealth;
    private Animator anim;
    public GameObject soundObject;
    //private GameObject radial;    
    private ScreenTransition screenTransition;
    
    public GameObject EnemyBullet;
    public Transform player;
    public Transform shotPoint;

    private void Start(){
        halfHealth=health*3/5;
        player=GameObject.FindGameObjectWithTag("Player").transform;
        anim=GetComponent<Animator>();
        screenTransition=FindObjectOfType<ScreenTransition>();
    }

    public void RangedAttack(){
        if(player!=null){
        Vector2 direction=player.position-shotPoint.position; 
        float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        Quaternion rotation =Quaternion.AngleAxis(angle-90,Vector3.forward);
        shotPoint.rotation=rotation;
        Instantiate(EnemyBullet,shotPoint.position,shotPoint.rotation);
        }
    }
    public void TakeDamage(int amount){   
        health-=amount;
        if(health<=0){
            Destroy(this.gameObject);
            Instantiate(soundObject,transform.position,transform.rotation);
            /*
            if(GameObject.FindGameObjectsWithTag("Enemy").Length!=0){
            
                foreach(GameObject child in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    Destroy(child.gameObject);
                }
                StartCoroutine(Order());
                screenTransition.LoadScene("Win");  
            }
            else{
                screenTransition.LoadScene("Win");  
            }
            */
        }
        if(health<=halfHealth){
            anim.SetTrigger("stage2");   
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag=="Player"){
            collision.GetComponent<PlayerMovement>().TakeDamage(damage);
        }
    }
}

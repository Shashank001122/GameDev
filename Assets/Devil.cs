using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public OurEnemy[] enemies;
    public float spawnOffset;
    public int damage;
    private int halfHealth;
    private Animator anim;
    private ScreenTransition screenTransition;
    private void Start(){
        halfHealth=health/2;
        anim=GetComponent<Animator>();
        screenTransition=FindObjectOfType<ScreenTransition>();
    }

    public void TakeDamage(int amount){
        health-=amount;
        if(health<=0){
            Destroy(this.gameObject);
            screenTransition.LoadScene("Win");
        }

        if(health<=halfHealth){
            anim.SetTrigger("stage2");
            Debug.Log("triggered");  
        }
        //OurEnemy randomEnemy=enemies[Random.Range(0,enemies.Length)];
        //Instantiate(randomEnemy,transform.position+new Vector3(spawnOffset,spawnOffset,0),transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag=="Player"){
            collision.GetComponent<PlayerMovement>().TakeDamage(damage);
        }
    }
}

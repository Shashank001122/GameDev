using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
   public float speed;
   private Rigidbody2D rb;
   private Vector2 moveAmount;//how much we are going to move..
   private Animator anim; 

   public int health;

   public Image[] hearts;
   public Sprite fullHeart;
   public Sprite emptyHeart;
   WaveSpawnner WaveSpawnnerScript;
    public int wavenumber;
  public Animator hurtAnim;
  private ScreenTransition screenTransition;
 
   private void Start(){
       anim=GetComponent<Animator>();
       rb=GetComponent<Rigidbody2D>();
       screenTransition=FindObjectOfType<ScreenTransition>();
   }

   private void Update(){
       Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveAmount=moveInput.normalized*speed;
          
        if (moveInput!=Vector2.zero){ //chahracter is running
            anim.SetBool("ISRunning",true);
        }
        else{
            anim.SetBool("ISRunning",false); 
        }

              
   }
    private void FixedUpdate(){ //any code related to physics goes inside this function
        rb.MovePosition(rb.position + moveAmount*Time.fixedDeltaTime);
    }

    public void TakeDamage(int damageAmount){
        health-=damageAmount;
        UpdateHealthUI(health);
        hurtAnim.SetTrigger("hurt");
        if (health<=0){
            Destroy(gameObject);
            if(GameObject.FindGameObjectWithTag("Player")==null){
            screenTransition.LoadScene("Lose");
            }
            }
        }
    


    //////////Change weapon is called///////////
    public void ChangeWeapon(Weapon WeaponToEquip){
        
    GameObject playerObject=GameObject.FindGameObjectWithTag("Player");
    int i = 0;

    //Array to hold all child obj
    GameObject[] allChildren = new GameObject[playerObject.transform.childCount];

    //Find all child obj and store to that array
    foreach (Transform child in playerObject.transform)
    {
        allChildren[i] = child.gameObject;
        i += 1;
    }

    //Now destroy them
    foreach (GameObject child in allChildren)
    {
        if((child.transform.name != "healthbar")  && (child.transform.name != "body") && (child.transform.name != "leg left") && (child.transform.name != "leg right"))
            Destroy(child.gameObject);
    }

        Instantiate(WeaponToEquip,transform.position,transform.rotation,transform);
        //Debug.Log("From player movemenet weapon assigned"+WeaponToEquip);

    } 

    void UpdateHealthUI(int currentHealth){
        for(int i=0;i<hearts.Length;i++){
            if(i<currentHealth){
                hearts[i].sprite=fullHeart;
            }    
            else{
                hearts[i].sprite=emptyHeart;
            }

        }
    }


    public void Heal(int healamount){
        if(health+healamount>6){
            health=6;
        }
        else{
            health=health+healamount;
        }
        UpdateHealthUI(health);
        
    }  
}

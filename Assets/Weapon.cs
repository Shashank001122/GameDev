/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public Transform shotPoint;
    public float timeBetweenShots;
    private float shotTime;

    // Update is called once per frame
    private void Update()
    {
        Vector2 direction=Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        Quaternion rotation =Quaternion.AngleAxis(angle-90,Vector3.forward);
        transform.rotation=rotation;

        if(Input.GetMouseButton(0)){
            if (Time.time>=shotTime){
                Instantiate(projectile,shotPoint.position,transform.rotation);
                shotTime=Time.time+timeBetweenShots;  //time between each shot the player has to wait..
            }
        }
        
             
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public Transform shotPoint;
    public float timeBetweenShots;
    private float shotTime;

    Animator cameraAnim;

    public Joystick joystick2;

    private void Start(){
        cameraAnim = Camera.main.GetComponent<Animator>();
    }
    
    // Update is called once per frame
    private void Update()
    {
        //joystick2=GameObject.FindObjectOfType<Joystick>();
        //Debug.Log("joy"+GameObject.FindGameObjectWithTag("Weapon").transform.name+joystick2);
        if( GameObject.FindGameObjectWithTag("Weapon").transform.name=="weapon_1(Clone)"||
            GameObject.FindGameObjectWithTag("Weapon").transform.name=="weapon_2(Clone)"||
            GameObject.FindGameObjectWithTag("Weapon").transform.name=="weapon_3(Clone)"||
            GameObject.FindGameObjectWithTag("Weapon").transform.name=="gun(Clone)" ||
            GameObject.FindGameObjectWithTag("Weapon").transform.name=="finalweapon(Clone)"){
           
           GameObject obj=GameObject.FindGameObjectWithTag("weaponjoystick");
           joystick2=obj.GetComponent<Joystick>();
       }
        var x =joystick2.Horizontal;
        var y =joystick2.Vertical;
        
        
        if (x != 0.0 || y != 0.0){//x zero nahi hona chahiye ya y zero nahi hona chahiye
            var angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
            Quaternion rotation =Quaternion.AngleAxis(angle-90,Vector3.forward);
            transform.rotation=rotation;
            //bool chk=GameObject.FindGameObjectWithTag("Player").GetComponent<MyJoyStick>().check;
        
            if (Time.time>=shotTime){
                Instantiate(projectile,shotPoint.position,transform.rotation);
                cameraAnim.SetTrigger("shake");
                shotTime=Time.time+timeBetweenShots;//time between each shot the player has to wait..
            }
    
        }
    }
}

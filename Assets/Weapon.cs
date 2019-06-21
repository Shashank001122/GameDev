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
    //public Joystick joystick2;
    

    // Update is called once per frame
    private void Update()
    {
        
        Vector2 direction=Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        Quaternion rotation =Quaternion.AngleAxis(angle-90,Vector3.forward);
        transform.rotation=rotation;
        bool chk=GameObject.FindGameObjectWithTag("Player").GetComponent<MyJoyStick>().check;
        
        if(Input.GetMouseButton(0)){
            if (Time.time>=shotTime){
                Instantiate(projectile,shotPoint.position,transform.rotation);
                shotTime=Time.time+timeBetweenShots;//time between each shot the player has to wait..
            }
        }
        /* 
        //Vector2 touchPosition =new Vector2(joystick2.Horizontal,joystick2.Vertical);

                // Get a Directional Vector from the Joystick input / offset from center
        //Vector2 targetDirection = new Vector2( touchPosition.x,touchPosition.y );
        
        // Quaternion.LookRotation logs an error if the forward direction is zero.
        // check if targetDirection is NOT Vector3.zero
        Vector2 targetDirection=Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        //float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        //Quaternion rotation =Quaternion.AngleAxis(angle-90,Vector3.forward);
        //transform.rotation=rotation;
        bool chk=GameObject.FindGameObjectWithTag("Player").GetComponent<MyJoyScript>().check;
        
        if ( targetDirection!= Vector2.zero && chk==false)
        {
            if (Time.time>=shotTime){
                float angle=Mathf.Atan2(targetDirection.y,targetDirection.x)*Mathf.Rad2Deg;
                Quaternion rotation =Quaternion.AngleAxis(angle-90,Vector3.forward);
                transform.rotation=rotation;
                Instantiate(projectile,shotPoint.position,transform.rotation);
                shotTime=Time.time+timeBetweenShots;//time between each shot the player has to wait..
            }
            
        }  */      
    }
}

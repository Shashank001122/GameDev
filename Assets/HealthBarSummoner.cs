using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarSummoner : MonoBehaviour
{
    Vector2 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale=transform.localScale*6/8;
    }

    // Update is called once per frame
    void Update()
    {
        float health=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().health;
        localScale.x=health/3;
        transform.localScale=localScale;
    }
}

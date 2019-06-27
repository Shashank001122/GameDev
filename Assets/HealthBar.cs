using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Vector2 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale=transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float health=GameObject.FindGameObjectWithTag("devil").GetComponent<Devil>().health;
        localScale.x=health/18;
        transform.localScale=localScale;
    }
}

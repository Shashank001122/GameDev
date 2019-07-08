using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale=transform.localScale;
        Debug.Log(localScale);
    }

    // Update is called once per frame
    void Update()
    {
        float health=GameObject.FindGameObjectWithTag("devil").GetComponent<Devil>().health;
        localScale.x=health/40.0f;
        transform.localScale=localScale;
        Debug.Log(localScale);
    }
}

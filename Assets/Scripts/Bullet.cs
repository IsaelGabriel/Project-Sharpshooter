using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 60f;
   
    private float distance = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * velocity * Time.deltaTime;
        distance += velocity * Time.deltaTime;
        if(distance > 50f) Destroy(gameObject); 
    }

    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Target")
        {
            Destroy(c.gameObject);
        }
        Destroy(gameObject);
    }
}

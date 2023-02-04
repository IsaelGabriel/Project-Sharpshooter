using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : SignalHandler
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
        SendSignal("BulletHit");

        if(c.gameObject.tag == "Target")
        {
            SendSignal("TargetHit");

            Destroy(c.gameObject);
        }
        
        Destroy(gameObject);
    }
}

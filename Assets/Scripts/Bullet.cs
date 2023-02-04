using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : SignalHandler
{
    
    /// Base bullet velocity.
    public float velocity = 60f;

    /// Bullet Distance count.
    private float distance = 0f;

    void Update()
    {
        transform.position += transform.forward * velocity * Time.deltaTime; /// Bullet moves in the direction it faces.
        distance += velocity * Time.deltaTime; /// Increase distance count.
        if(distance > 50f) Destroy(gameObject);  /// If distance is higher than 50 units, destroy bullet.
    }

    void OnCollisionEnter(Collision c)
    {
        SendSignal("BulletHit"); /// Send Signal to it's listeners, can be used to play a sound when colliding for example.

        if(c.gameObject.tag == "Target")
        {
            SendSignal("TargetHit");

            Destroy(c.gameObject); /// Destroy target object.
        }
        
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This object exists so the player doesn't recognize walls as ground.
public class GroundCheck : SignalHandler
{

    void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Ground") SendSignal("PlayerGrounded");
    } 

    void OnTriggerExit(Collider c)
    {
        if(c.tag == "Ground") SendSignal("!PlayerGrounded");
    }
}

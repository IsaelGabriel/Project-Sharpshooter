using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

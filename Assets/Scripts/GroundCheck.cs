using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour player;

    void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Ground") player.grounded = true;
    } 

    void OnTriggerExit(Collider c)
    {
        if(c.tag == "Ground") player.grounded = false;
    }
}

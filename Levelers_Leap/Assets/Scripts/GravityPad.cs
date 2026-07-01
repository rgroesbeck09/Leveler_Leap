using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPad : MonoBehaviour
{
    public float jumpMultiplier = 2f;

    private void OnTriggerEnter(Collider other)
    {
        MovementInput player = other.GetComponent<MovementInput>();

        if(player != null)
        {
            player.onGravityPad = true;
            player.jumpMultiplier = jumpMultiplier;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        MovementInput player = other.GetComponent<MovementInput>();

        if(player != null)
        {
            player.onGravityPad = false;
        }
    }
}

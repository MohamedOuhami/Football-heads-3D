using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    // In this function, you'll find the methods related to each power-up
    Movement movementscr;

    // Start function
    private void Start() {

        movementscr = GetComponent<Movement>();
    }

    // Update function
    private void Update() {
        
        // Calling the light speed method
        if(Input.GetKeyDown(KeyCode.T))
        {
            LightSpeed();
        }

        // Calling the Huge Head method
        if(Input.GetKeyDown(KeyCode.Y))
        {
            HugeHead();
        }

        // Calling the invisibility method
        if(Input.GetKeyDown(KeyCode.U))
        {
            Invisibility();
        }
    }


    // Power-Up #1 : Light Speed 
    void LightSpeed()
    {
        movementscr.speed *= 2;
    }
    // Power-Up #2 : Huge Head
    void HugeHead()
    {
        transform.localScale *= 2;
    }
    // Power-Up #3 : Invisibility
    void Invisibility()
    {
        Transform child = this.gameObject.transform.GetChild(0);
        child.GetComponent<Renderer>().enabled = false;
    }
}

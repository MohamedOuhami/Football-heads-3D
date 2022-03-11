using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Variables
    public CharacterController controller;
    public float speed;
    public Transform cam;
    public float turnSmoothTurn = 0.1f;
    float turnSmoothVelocity;
    // Gravity variables
    

    private void Update() {

        
        // Calling the MovementMechanic method
        MovementMechanic();
    }


    // The MovementMechanic method

    void MovementMechanic()
    {

        // Getting the movement direction ( With the horizontal and Vertical input system )
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal,0,Vertical).normalized;

        // When pressing a direction input button
        if(direction.magnitude >= 0.1f)
        {
            // Getting the target angle to rotate the player towards ( We don't want him to only face forwards ) " Camera included "
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            // Smoothly change the rotation for Its current one to the targeted angle with a turnSoothturn 
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity,turnSmoothTurn);
            // Setting the player's rotation angle to angle
            transform.rotation = Quaternion.Euler(0,angle,0);

            // Making the player goes forwards related to the angle he's facing
            Vector3 movedir = Quaternion.Euler(0,targetAngle,0) * Vector3.forward;
            controller.Move(movedir.normalized * speed * Time.deltaTime);
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementP2 : MonoBehaviour
{
   // Variables
    public Rigidbody rb;
    public float speed;
    public Transform cam;
    public float turnSmoothTurn = 0.1f;
    float turnSmoothVelocity;
    public float thrust;
    protected bool isGrounded;

    // Start function
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    private void Update() {
        
        
        // Calling the MovementMechanic method
        if(isGrounded == true)
        {
            MovementMechanic();
        }


        // Calling the jump Mechanism
        if(Input.GetKeyDown(KeyCode.P) && isGrounded == true)
        {
            Jump();
        }



    }


    // The MovementMechanic method

    void MovementMechanic()
    {

        // Getting the movement direction ( With the horizontal and Vertical input system )
        float horizontal = Input.GetAxis("HorizontalPlayer2");
        float Vertical = Input.GetAxis("VerticalPlayer2");
        Vector3 direction = new Vector3(horizontal,0,Vertical);

        // When pressing a direction input button
        if(direction.magnitude >= 0.1f)
        {
            // Getting the target angle to rotate the player towards ( We don't want him to only face forwards ) " Camera included "
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            // Smoothly change the rotation for Its current one to the targeted angle with a turnSoothturn 
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity,turnSmoothTurn);
            // Setting the player's rotation angle to angle
            transform.rotation = Quaternion.Euler(0,angle,0);

            // Making the player goes forwards related to the angle he's facing
            Vector3 movedir = Quaternion.Euler(0,targetAngle,0) * Vector3.forward;
            
            rb.velocity = movedir * speed * Time.deltaTime ;
        }
    }

    // Jump Mechanism
    void Jump()
    {
        rb.AddForce(0,thrust,0,ForceMode.Impulse);
        isGrounded = false;

    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Pitch"))
        {
            isGrounded = true;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Cross-Platform floats for Input
    private float xInput, yInput;

    // Player movement speed
    public int speed;

    private Rigidbody2D body;
    public Animator animator;

    // Variable to check if player is moving
    private bool moving;

    // Variable to change in editor, depending on build target
    public bool mobile;

    // Joystick for mobile input
    public Joystick myJoystick;
    
    // public bool attacking; for attacks later on

    
    void Start () {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moving = false;
        // attacking = false;
    }
    
    // Update is called once per frame
    void FixedUpdate () {

        // Get input using .GetAxisRaw
        // Can be replaced by Joystick.Horizontal or Joystick.Vertical if the variable Mobile is set to True in the editor
        if(mobile == false)
        {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");
        } else {
            xInput = myJoystick.Horizontal;
            yInput = myJoystick.Vertical;
        }
        // If moving(Player gives Input), Then move with 3D Vector
        moving = (xInput != 0 || yInput != 0);
 
        if (moving)
        {
            var moveVector = new Vector3(xInput , yInput, 0);
            // We change the Rigidbody position to a Vector2, composed of Transform, Move direction, Speed and time.deltatime
            body.MovePosition(new Vector2((transform.position.x + moveVector.x * speed * Time.deltaTime), transform.position.y + moveVector.y * speed * Time.deltaTime));
            // We apply the Input variables to our Animator, for it to change animation
            animator.SetFloat("xInput", xInput);
            animator.SetFloat("yInput", yInput);
        }
        // Puts the player in a moving state
        animator.SetBool("moving", moving);
    }
}
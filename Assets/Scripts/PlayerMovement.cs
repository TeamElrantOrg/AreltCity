using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float xInput, yInput;
    public int speed;
    private Rigidbody2D body;
    public Animator animator;
    private bool moving;
    //Joystick for eventual mobile controls.
    // public joystick joystick;
    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moving = false;
        // attacking = false;
    }
    
    // Update is called once per frame
    void FixedUpdate () {
 
        // We'll use this code down here for attacks later on,
        // Works on gamepads too.
        //if(Input.GetButtonDown("Fire1"))
        // {
        //      animator.SetTrigger("Attack");
        // }
        // Get input using .GetAxisRaw
        // Can be replaced by 
        // Joystick.Horizontal or Joystick.Vertical

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
 
        // If moving(Player gives Input), Then move with 3D Vector
        moving = (xInput != 0 || yInput != 0);
 
        if (moving)
        {
            var moveVector = new Vector3(xInput , yInput, 0);   
 
            // BAD MOVEMENT - Circumvents RigidBody2D Physics
            // transform.position += moveVector * speed * Time.deltaTime;
            // CORRECT MOVEMENT
            body.MovePosition(new Vector2((transform.position.x + moveVector.x * speed * Time.deltaTime), transform.position.y + moveVector.y * speed * Time.deltaTime));
            animator.SetFloat("xInput", xInput);
            animator.SetFloat("yInput", yInput);
        }
        animator.SetBool("moving", moving);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MOVEMENT : MonoBehaviour
{
    // PLAYER MOVEMENT SPEED
    public float Speed;
    // Player jump length means how far the player can jump 
    public float jumpPower;

    // PLAYER GAMEOBJECT RIGID BODY Component
    private Rigidbody2D RIGIDBODY;
    // This will hold camera
    private GameObject Camera;
    // This member will hold the boolean value whether the player is on ground or not
    private bool grounded;

    //Selection of the layers to be avilable
    public LayerMask GroundLayer;
    // variable will hold collider
    private Collider2D Collider;

    // This Animator will be used to play animations of run,jump,slide
    private Animator Animator;
    void Start()
    {
        // These lines will be used to assign components
        RIGIDBODY = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
        Animator = GetComponent<Animator>();
        Camera = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update()
    {

        // IF game is in running state
        if(GAMEMECHANICS.state=="running")
        {
            // By this line camera moves whenever player moves
            Camera.transform.position = new Vector3(this.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
            // To check if player is touching the ground
            grounded = Physics2D.IsTouchingLayers(Collider, GroundLayer);

            // MOVING ANIMATION CHECK
            // IF PLAYER IS NOT MOVING RIGHT AND NOT MOVING LEFT OR NOT ON GROUND
            // THEN MOVING ANIMATION IS FALSE
            // OTHERWISE TRUE
            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) &&!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) || !grounded)
                Animator.SetBool("Moving", false);
            else
                Animator.SetBool("Moving", true);

            // TO MOVE RIGHT 
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                RIGIDBODY.velocity = new Vector2(Speed, RIGIDBODY.velocity.y);
                // ROTATION WILL BE USED FOR RIGHT MOVEMENT ANIMTAITON
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            //To move Left
            if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
            {
                RIGIDBODY.velocity = new Vector2(-Speed, RIGIDBODY.velocity.y);
                // Rotate the game object by 180 degree so that player seems moving in left direction
                transform.rotation = Quaternion.Euler(0, 180, 0);
                
            }

            // To slide
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                // If player is not on the ground then player will slide otherwise not
                if (grounded && (!(Input.GetKey(KeyCode.D))))
                {
                   
                    transform.position = new Vector3(transform.position.x, -3.3f, transform.position.z);
                    // turn on Slide animation
                    Animator.SetBool("Slide", true);

                    RIGIDBODY.velocity = new Vector2(Speed * 2, RIGIDBODY.velocity.y);
                    // Player will slide for 0.1 millisecond
                    Invoke("removeslide", 0.1f);
                }


            }

            // For jump
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {

                // If player is on ground then player will jump
                if (grounded)
                    RIGIDBODY.velocity = new Vector2(RIGIDBODY.velocity.x, jumpPower);
            }



            // If player is on ground then jump animation will not run
            Animator.SetBool("Grounded", grounded);


        }

        
    }
    public void removeslide()
    {
        // turn off slide animation
        Animator.SetBool("Slide", false);
    }
}

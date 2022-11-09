using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 50f;

    float swimmingGravityForce = 3;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButton("Jump") || Input.GetKey(KeyCode.W))
        {
            jump = true;
            verticalMove = swimmingGravityForce;
        }


        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            verticalMove = swimmingGravityForce;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        print(verticalMove);
    }

    void FixedUpdate ()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove, crouch, jump);
        jump = false;
    }
}

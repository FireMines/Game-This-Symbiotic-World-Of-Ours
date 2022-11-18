using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 50f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool isSwimming = false;
    bool swimUp = false;
    bool swimDown = false;

    private bool dashPowerup = false;
    //Dash controls
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 44f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 3f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;

    

    private void OnTriggerEnter2D(Collider2D hit){
		// If we are entering something else than water, return
		if (hit.gameObject.tag != "Water") return;

		//if player hits the edge of the water, either he goes from swim->!swim or from !swim->swim
		isSwimming = true;
        print(isSwimming);
		
	}

	private void OnTriggerExit2D(Collider2D hit){
		// If we are exiting something else than water, return
		if (hit.gameObject.tag != "Water") return;
		
		//if player hits the edge of the water, either he goes from swim->!swim or from !swim->swim
        isSwimming = false;
		swimUp = false;
        swimDown=false;
		print(isSwimming);
	}

    // Update is called once per frame
    void Update()
    {
        dashPowerup = controller.DashPowerup;
        //Cant do anything else when dashing
        if (isDashing)
        {
            return;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && !isSwimming)
        {
            jump = true;
        }

        if (Input.GetButtonDown("Jump") && isSwimming)
        {
            swimUp = true;
        } else if (Input.GetButtonUp("Jump") && isSwimming)
        {
            swimUp = false;
        }

        if (Input.GetButtonDown("Crouch") && isSwimming)
        {
            swimDown = true;
        } else if (Input.GetButtonUp("Crouch") && isSwimming)
        {
            swimDown = false;
        }

        if (Input.GetButtonDown("Crouch") && !isSwimming)
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch") && !isSwimming)
        {
            crouch = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && dashPowerup)
        {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate ()
    {
        //Cant do anything else when dashing
        if (isDashing)
        {
            return;
        }

        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, swimUp, swimDown);
        jump = false;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        print("CanDash " + canDash + ", cooldown "+dashingCooldown);
        canDash = true;
    }

    public void setSpeed(float speed){
        runSpeed = speed;
    }
}

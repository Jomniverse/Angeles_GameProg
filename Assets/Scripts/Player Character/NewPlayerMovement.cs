using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    //walking and jumping
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;

    //dashing
    private bool canDash = true;
    private bool isDashing;
    private bool hasAirDashed = false;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;


    //Coyote time = ability to jump a few seconds after leaving ground
    public float coyoteTime = 0.2f;
    public float coyoteTimeCounter;

    //Jump buffer = ability to jump before landing but still activate that jump once hitting ground
    public float jumpBufferTime = 0.2f;
    public float jumpBufferCounter;

    //Double jump
    private bool doubleJump;

    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer trail;

    public float xInput;


    // Update is called once per frame
    void Update()
    {
        GetInput();

        CoyoteJump();

        JumpBuffer();

        MoveWithInput();

        Flip();

    }

    //for getting the user input
    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");

    }

    //Effects of user input
    void MoveWithInput()
    {

        //Can only jump if it's within the ground or before the delay jump counter turn 0
        //Will also make the user jump if pressed a short duration before landing
        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpingPower);

            jumpBufferCounter = 0f;

        }

        if (Input.GetButtonUp("Jump") && body.linearVelocity.y > 0f)
        {
            //If quick tap it will result into a small jump but long tap will result to a higher jump
            body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y * 0.5f);


            //Prevent the player from double jumping
            coyoteTimeCounter = 0f;

        }

        //To activate dashing
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (IsGrounded() && canDash) // Ground dash uses cooldown
            {
                StartCoroutine(Dash(true));
            }
            else if (!IsGrounded() && !hasAirDashed) // Air dash only once per jump
            {
                StartCoroutine(Dash(false));
                hasAirDashed = true;
            }
        }


    }

    //Allows jumping a short ammount of time after leaving the ground
    void CoyoteJump()
    {
        //Counter will not countdown if grounded
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
            hasAirDashed = false; // Reset air dash when landing
        }

        //counter will count down if not on ground
        else
        {
            coyoteTimeCounter -= Time.deltaTime;

            if (coyoteTimeCounter < 0f)
            {
                coyoteTimeCounter = 0f;
            }
        }

    }

    //Allows jump to happen before hitting the ground and will activate once landed
    void JumpBuffer()
    {
        //Counter will not countdown until jump has been activated again
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;

        }

        //Counter will count down after hitting jump 
        else
        {
            jumpBufferCounter -= Time.deltaTime;

            if (jumpBufferCounter < 0f)
            {
                jumpBufferCounter = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        //Making sure the dash is working
        if (isDashing)
        {
            return;
        }

        //calculating the walking value
        body.linearVelocity = new Vector2(xInput * speed, body.linearVelocity.y);
    }

    //Creating a hitbox under the player to know if it's on the ground
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //For changing direction of the player
    private void Flip()
    {
        if (isFacingRight && xInput < 0f || !isFacingRight && xInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


    //Dashing mechanic
    private IEnumerator Dash(bool isGroundDash)
    {
        canDash = false;
        isDashing = true;

        //Making sure that gravity won't effect dash to make it straight
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;

        //indicate where the dash is directed
        body.linearVelocity = new Vector2(transform.localScale.x * dashingPower, 0f);

        //displaying the trail
        trail.emitting = true;

        //When the dash will stop
        yield return new WaitForSeconds(dashingTime);
        trail.emitting = false;
        body.gravityScale = originalGravity;
        isDashing = false;

        if (isGroundDash) // cooldown only for ground dash
        {
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;
        }
        else
        {
            // For air dash, canDash stays false until landing
        }
    }
}

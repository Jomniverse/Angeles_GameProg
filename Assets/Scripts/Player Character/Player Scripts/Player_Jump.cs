using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    [Header("Jumping Stats")]
    [SerializeField] private float jumping_power = 16f;
    [SerializeField] private bool doubleJump = true;

    [Header("CoyoteTime")]
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float coyoteTimeCounter;

    [Header("Jump Buffering")]
    [SerializeField] private float jumpBufferTime = 0.2f;
    [SerializeField] private float jumpBufferCounter;

    private bool wasGrounded;

    [Header("Unlockable")]
    [SerializeField] private Player_Unlockable PU;

    [Header("Reference")]
    public Rigidbody2D player;
    [SerializeField] private Player_Grounded PGround;
    [SerializeField] private Player_Dash PDash;


    private void Update()
    {
        HandleJumpInput();
        JumpBuffer();
        CoyoteJump();

        if (PGround.grounded && !wasGrounded)
        {
            PDash.canGroundDash = true;
        }

        wasGrounded = PGround.grounded;
    }

    //============================== JUMPING ============================
    void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }

        if (jumpBufferCounter > 0f)
        {
            TryJump();
        }

        if (Input.GetButtonUp("Jump") && player.linearVelocityY > 0f)
        {
            HighJump();
        }
    }

    void TryJump()
    {
        if (coyoteTimeCounter > 0f)
        {
            NormalJump();
            doubleJump = true;

        }

        else if (doubleJump && PU.unlockDoubleJump)
        {
            NormalJump();
            doubleJump = false;
        }

    }

    void NormalJump()
    {
        player.linearVelocity = new Vector2(player.linearVelocityX, jumping_power);
        coyoteTimeCounter = 0f;
        jumpBufferCounter = 0f;
        PDash.canAirDash = true;
    }


    void HighJump()
    {
        player.linearVelocity = new Vector2(player.linearVelocityX, player.linearVelocityY * 0.5f);
        coyoteTimeCounter = 0f;
    }

    //========================= Coyote Time =============================
    void CoyoteJump()
    {
        if (PGround.grounded)
        {
            coyoteTimeCounter = coyoteTime;
        }

        else
        {
            coyoteTimeCounter -= Time.deltaTime;

            if (coyoteTimeCounter < 0f)
            {
                coyoteTimeCounter = 0f;
            }
        }

    }

    //========================= Jump Buffer =============================

    void JumpBuffer()
    {
        if (jumpBufferCounter > 0f)
        {
            jumpBufferCounter -= Time.deltaTime;

            if (jumpBufferCounter < 0f)
                jumpBufferCounter = 0f;
        }
    }
}

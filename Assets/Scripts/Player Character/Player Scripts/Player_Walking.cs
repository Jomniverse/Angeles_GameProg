using UnityEngine;

public class Player_Walking : MonoBehaviour
{
    [Header("Walking Stats")]
    public float horizontal;
    [SerializeField] private float move_speed = 8f;
    [SerializeField] private bool isFacingRight = true;

    [Header("Reference")]
    public Rigidbody2D player;
    public Player_Dash PDash;

    void Update()
    {
        HandleMovementInput();
        
        FlipFacing();
    }

    private void FixedUpdate()
    {
        if (!PDash.isDashing)
        {
            player.linearVelocity = new Vector2(horizontal * move_speed, player.linearVelocity.y);
        }
    }

    //============================== MOVEMENT ===========================

    private void HandleMovementInput()
    {
        horizontal = Input.GetAxis("Horizontal");

    }

    private void FlipFacing()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}

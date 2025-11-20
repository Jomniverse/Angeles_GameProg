using System.Collections;

using UnityEngine;


public class Player_Dash : MonoBehaviour
{
    [Header("Dashing")]
    public bool canGroundDash = true;
    public bool canAirDash;
    public bool isDashing;
    public float dashing_power = 24f;
    public float dashing_time = 0.2f;
    public float dashing_cooldown = 1f;


    [Header("Unlockable")]
    [SerializeField] private Player_Unlockable PU;

    [Header("Reference")]
    [SerializeField] private TrailRenderer trail;
    public Rigidbody2D player;
    [SerializeField] private Player_Grounded PGround;


    private void Update()
    {
        HandleDashInput();
    }

    void HandleDashInput()
    {
        if(isDashing)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (canGroundDash && PGround.grounded)
            {
                StartCoroutine(Dash());
            }

            else if ((!PGround.grounded && canAirDash) && PU.unlockAirDash)
            {
                StartCoroutine(Dash());
                canAirDash = false;
            }
            
        }
    }
    //============================== DASHING ===========================

    private IEnumerator Dash()
    {
        canGroundDash = false;
        canAirDash = false;
        isDashing = true;

        //Making sure that gravity won't effect dash to make it straight
        float originalGravity = player.gravityScale;
        player.gravityScale = 0f;

        //indicate where the dash is directed
        player.linearVelocity = new Vector2(transform.localScale.x * dashing_power, 0f);

        //displaying the trail
        trail.emitting = true;

        //When the dash will stop
        yield return new WaitForSeconds(dashing_time);
        trail.emitting = false;
        player.gravityScale = originalGravity;
        isDashing = false;

        if (PGround.grounded) // cooldown only for ground dash
        { 
            yield return new WaitForSeconds(dashing_cooldown);
            canGroundDash = true;
        }
        
        else
        {
            // For air dash, canDash stays false until landing
        }
    }
}
using UnityEngine;

public class Player_WallJump : MonoBehaviour
{
    [Header("Wall Jump")]
    [SerializeField] private bool isWallSliding;
    [SerializeField] private float wallSlidingSpeed;

    [Header("Unlockable")]
    public bool unlockWallJump = false;

    [Header("Reference")]
    public Rigidbody2D player;
    [SerializeField] private BoxCollider2D wallChecker;
    [SerializeField] private LayerMask wallMask;


    private void WallSlide()
    {
        
    }

    void CheckWall()
    {
        isWallSliding = Physics2D.OverlapAreaAll(wallChecker.bounds.min, wallChecker.bounds.max, wallMask).Length > 0;
    }

}

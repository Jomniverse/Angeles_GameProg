using UnityEngine;

public class Player_Grounded : MonoBehaviour
{
    [Header("Ground Detection")]
    public bool grounded;
   

    [Header("Reference")]
    [SerializeField] private BoxCollider2D groundChecker;
    [SerializeField] private LayerMask groundMask;


    private void Update()
    {
        CheckGround();
    }

    // ===================== GROUND CHECK =====================

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundChecker.bounds.min, groundChecker.bounds.max, groundMask).Length > 0;
    }

}

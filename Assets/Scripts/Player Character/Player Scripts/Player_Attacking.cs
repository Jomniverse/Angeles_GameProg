using UnityEngine;

public class Player_Attacking : MonoBehaviour
{
    [Header("Attacking Stats")]
    [SerializeField] private bool canAttack = true;
    [SerializeField] private bool isAttacking;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private float attackCounter;
    [SerializeField] private float damage;
    [SerializeField] Transform side_Attack_Transform, up_Attack_Transform, down_Attack_Transform;
    [SerializeField] Vector2 side_Attack_Area, up_Attack_Area, down_Attack_Area;

    [Header("Inputs")]
    private float xAxis, yAxis;

    [Header("Reference")]
    public Rigidbody2D player;
    [SerializeField] private Player_Grounded PGround;
    [SerializeField] private LayerMask enemyMask;


    private void Update()
    {
        HandleAttackInput();
        AttackTimer();
    }

    //============================== ATTACKING ============================

    void HandleAttackInput()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");  

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        if (canAttack)
        {
            // Consume attack
            canAttack = false;
            attackCounter = 0f;

            if (yAxis == 0 || (yAxis < 0 && PGround.grounded))
            {
                HitBox(side_Attack_Transform, side_Attack_Area);
            }
            else if (yAxis > 0)
            {
                HitBox(up_Attack_Transform, up_Attack_Area);
            }
            else if (yAxis < 0 && !PGround.grounded)
            {
                HitBox(down_Attack_Transform, down_Attack_Area);
            }
        }
    }

    void AttackTimer()
    {
        // Only count up when you are not yet ready to attack
        if (!canAttack)
        {
            attackCounter += Time.deltaTime;

            // When attack counter reaches cooldown, allow attacking again
            if (attackCounter >= attackCooldown)
            {
                canAttack = true;
                attackCounter = attackCooldown; // stops it from going above
            }
        }

    }


    //============================== HITBOX ============================

    void HitBox(Transform _attackTransform, Vector2 _attackArea)
    {
        Collider2D[] objectsToHit = Physics2D.OverlapBoxAll(_attackTransform.position, _attackArea, 0, enemyMask);

        if(objectsToHit.Length > 0)
        {
            Debug.Log("Damaged");
        }
        for(int i = 0; i < objectsToHit.Length; i++)
        {
            if(objectsToHit[i].GetComponent<Enemy_Stats>() != null)
            {
                objectsToHit[i].GetComponent<Enemy_Stats>().EnemyDamaged(damage, (transform.position - objectsToHit[i].transform.position).normalized, 100);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (canAttack)
        {
            Gizmos.color = Color.green;
        }

        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireCube(side_Attack_Transform.position, side_Attack_Area);
        Gizmos.DrawWireCube(up_Attack_Transform.position, up_Attack_Area);
        Gizmos.DrawWireCube(down_Attack_Transform.position, down_Attack_Area);
        
    }
}

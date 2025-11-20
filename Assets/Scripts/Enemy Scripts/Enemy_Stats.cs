using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stats : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float health = 100f;

    [Header("Recoil")]
    [SerializeField] private float recoil_length = 0.2f;
    [SerializeField] private float recoil_factor = 5f;
    [SerializeField] private bool isRecoiling = false;
    [SerializeField] private float recoil_timer;

    [Header("References")]
    [SerializeField] private Rigidbody2D enemy;
    [SerializeField] private Enemy_Drop ED;
    

    private bool isDead = false; // to prevent double triggers

    private void Update()
    {
        if (!isDead && health <= 0)
        {
            isDead = true;
            Die();
        }

        if (isRecoiling)
        {
            if (recoil_timer < recoil_length)
            {
                recoil_timer += Time.deltaTime;
            }
            else
            {
                isRecoiling = false;
                recoil_timer = 0;
            }
        }
    }

    public void EnemyDamaged(float _damageDone, Vector2 _hitDirection, float _hitForce)
    {
        health -= _damageDone;
        if (!isRecoiling)
        {
            enemy.AddForce(-_hitForce * recoil_factor * _hitDirection);
            isRecoiling = true;
        }
    }

    void Die()
    {
        ED.DropLoot();
        Destroy(gameObject);
    }
}
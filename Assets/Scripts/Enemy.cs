using System.Collections;
using UnityEngine;
using System;
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] float enemyHealth = 30f;
    [Range(0.5f, 4f)]
    public float enemyDamage = 2f;
    public static event Action EnemyDied;
    public static event Action EnemySpawned;

    [SerializeField]private EnemyFlash enemyFlash;
   
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        enemyFlash.Flash();
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            EnemyDied?.Invoke();
        }
    }

}

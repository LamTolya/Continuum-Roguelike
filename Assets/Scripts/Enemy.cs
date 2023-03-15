using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Events;
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] float enemyHealth = 30f;
    [Range(0.5f, 4f)]
    public float enemyDamage = 2f;
    public static event Action EnemyDied;
    public static event Action EnemySpawned;
    public UnityEvent EnemyAttacked;
    EnemyMessenger messanger;

    void Start()
    {
        if (GetComponent<EnemyMessenger>() == null) messanger = gameObject.AddComponent<EnemyMessenger>();
    }

    public float GetHealth()
    {
        return enemyHealth;
    }
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        messanger.SentDamage(damage);
        EnemyAttacked?.Invoke();

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            EnemyDied?.Invoke();
        }
    }

}

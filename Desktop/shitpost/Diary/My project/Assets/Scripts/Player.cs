using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private PlayerInput playerInput;

    public static event Action<GameObject> PlayerActivated;
    public static event Action PlayerDamaged;
    public static event Action PlayerDied;
    public UnityEvent PlayerAttacked;

    public void TakeDamage(float damage)
    {
        PlayerAttacked?.Invoke();
        if (playerData.Health-damage <= 0)
        {
            PlayerDied?.Invoke();
        }
        else
        {
            playerData.Health -= damage;
        }
        PlayerDamaged?.Invoke();

    }

    private void Start()
    {
        PlayerActivated?.Invoke(gameObject);
    }

    private void Update()
    {
        playerInput.Update();
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class AttackingController : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private TriggerInput triggerInput;

    [SerializeField]
    private List<Collider> hitColliders;
    public static event Action AttackFinished;

    private void OnEnable()
    {
        OnTriggerEntered.TriggerActivated += SetColliders;
        PlayerInput.ClickEvent += Attack;

    }

    private void OnDisable()
    {
        OnTriggerEntered.TriggerActivated -= SetColliders;
        PlayerInput.ClickEvent -= Attack;
    }

    void SetColliders(List<Collider> list)
    {
        hitColliders = list;
    }

    private void Attack()
    {
        DealDamage(hitColliders);
    }

    private void DealDamage(List<Collider> hitList)
    {
        bool AttackOnEnemies = false;
        foreach (Collider collider in hitList)
        {
            if (collider.GetComponent<Player>() == null && collider.GetComponent<IDamageable>() != null) 
            {
                collider.GetComponent<IDamageable>().TakeDamage(playerStats.AttackDamage);
                AttackOnEnemies = true;
            } 
        }

        if (AttackOnEnemies)
        {
            AttackFinished?.Invoke();
        }
    }
   
}


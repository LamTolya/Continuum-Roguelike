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
        if (hitColliders.Count > 0) 
        {
            AttackFinished?.Invoke(); 
        }

        Debug.Log("attacking" + playerStats.AttackDamage);
    }

    private void DealDamage(List<Collider> hitList)
    {
        foreach (Collider collider in hitList)
        {
            collider.gameObject.GetComponent<AddImpulse>()?.AddForce(gameObject.transform.position, 2000, -1);
            collider.gameObject.GetComponent<Enemy>()?.TakeDamage(playerStats.AttackDamage);
        }
    }
   
}


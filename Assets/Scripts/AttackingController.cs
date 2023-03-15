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

    float reload_cd;
    bool weaponCooldown;
    private void OnEnable()
    {
        OnTriggerEntered.TriggerActivated += SetColliders;
        PlayerInput.ClickEvent += Attack;
        Weapon.WeaponInteracted += GetWeaponData;

    }

    void GetWeaponData(Weapon weapon)
    {
        ReloadSettings(weapon.GetWeaponData().ReloadTime);
    }

    void ReloadSettings(float _reload_cd)
    {
        reload_cd = _reload_cd;
    }
    void SetReload() 
    {
        weaponCooldown = true;
        Invoke(nameof(ResetReload), reload_cd);
    }

    void ResetReload()
    {
        weaponCooldown = false;
    }

    private void OnDisable()
    {
        OnTriggerEntered.TriggerActivated -= SetColliders;
        PlayerInput.ClickEvent -= Attack;
        Weapon.WeaponInteracted -= GetWeaponData;
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
        if (weaponCooldown == true) return;

        bool AttackOnEnemies = false;
        foreach (Collider collider in hitList)
        {
            if ( collider != null && collider.GetComponent<Player>() == null && collider.GetComponent<IDamageable>() != null) 
            {
                collider.GetComponent<IDamageable>().TakeDamage(playerStats.AttackDamage);
                AttackOnEnemies = true;
            } 
        }

        if (AttackOnEnemies)
        {
            AttackFinished?.Invoke();
            SetReload();
        }
    }
   
}


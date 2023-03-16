using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/Player Stats", order = 3)]
public class PlayerStats : ScriptableObject
{
    [System.NonSerialized]  public float Speed = 3;
    [System.NonSerialized] public float Defense;
    [System.NonSerialized] public float Favor;
    [System.NonSerialized] public float AttackDamage;
    public static event Action StatsChanged;
    public PlayerEquipments PlayerEquipments;

    private float BaseDamage = 3;
    

    private void OnEnable()
    {
        Weapon.WeaponInteracted += UpdateStats;
        Totem.TotemEquiped += ModifyStats;
        Player.PlayerDied += ResetStats;
    }
    private void OnDisable()
    {
        Weapon.WeaponInteracted -= UpdateStats;
        Totem.TotemEquiped -= ModifyStats;
        Player.PlayerDied -= ResetStats;
    }

    private void UpdateStats(Weapon Weapon)
    {
        WeaponData weaponData = Weapon.GetWeaponData();
        AttackDamage = BaseDamage + weaponData.WeaponDamage;
        Debug.Log($"Player Stats: Weapon's Damage: {weaponData.WeaponDamage}");

        StatsChanged?.Invoke();
    }

    private void ModifyStats(TotemData totemData)
    {
        AttackDamage += totemData.DamageModifier;
        Speed += Speed*totemData.SpeedModifier;
        Defense += totemData.DefenseModifier;
        Favor += totemData.FavorModifier;

        StatsChanged?.Invoke();
    }

    void ResetStats()
    {
        AttackDamage = BaseDamage;
        Speed = 3;
        StatsChanged?.Invoke();
    }
}

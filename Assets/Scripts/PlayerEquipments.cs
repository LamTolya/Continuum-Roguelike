using UnityEngine;
using System;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "Player Equipments", menuName = "Player/Player Equipments", order = 3)]
public class PlayerEquipments: ScriptableObject
{ 

    [NonSerialized] public WeaponData WeaponEquipment;

    public void SetWeaponEquipment(Weapon weapon)
    {
        WeaponData weaponData = weapon.GetWeaponData();
        WeaponEquipment = weaponData;
        Debug.Log($"Player Equipments: Weapon: {weaponData.ItemName}");
    }

    public void ResetEquipments()
    {
        WeaponEquipment = null;
    }
    public void OnEnable()
    {
        Weapon.WeaponInteracted += SetWeaponEquipment;
        Weapon.WeaponDestroyed += ResetEquipments;
        Player.PlayerDied += ResetEquipments;
    }

    private void OnDisable()
    {
        Weapon.WeaponInteracted -= SetWeaponEquipment;
        Weapon.WeaponDestroyed -= ResetEquipments;
        Player.PlayerDied -= ResetEquipments;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class WeaponHolder : MonoBehaviour
{
    
    [SerializeField] private GameObject defaultWeapon;
    [SerializeField] private Weapon CurrentWeapon;
    [SerializeField] private Transform WeaponTransform;
    [SerializeField] private PlayerEquipments PlayerEquipments;

    private void Start()
    {
        WearDefault();
    }

  
    private void WearDefault()
    {
        Debug.Log("default weapon on.");
        defaultWeapon.SetActive(true);
        defaultWeapon.GetComponent<Weapon>().Interact();
        CurrentWeapon = defaultWeapon.GetComponent<Weapon>();
    }


    void ResetHold()
    {
        CurrentWeapon.GetComponent<Weapon>().SetOff();
        CurrentWeapon = null;
        WearDefault();
    }

    private void UpdateHold(Weapon newWeapon)
    {
        if (newWeapon == null) return;

        if (CurrentWeapon != null)
        {
            CurrentWeapon.GetComponent<Weapon>().SetOff();
            CurrentWeapon = null;
        }
        CurrentWeapon = newWeapon;
        newWeapon.gameObject.transform.position = WeaponTransform.position;
        newWeapon.gameObject.transform.parent = WeaponTransform;
        BoxCollider collider = newWeapon.GetComponent<BoxCollider>();
        if (collider != null) collider.enabled = false;
    }

    private void OnEnable()
    {
        Weapon.WeaponDestroyed += WearDefault;
        Player.PlayerDied += ResetHold;
        Weapon.WeaponInteracted += UpdateHold;
    }
    private void OnDisable()
    {
        Player.PlayerDied -= ResetHold;
        Weapon.WeaponDestroyed -= WearDefault;
        Weapon.WeaponInteracted -= UpdateHold;
    }
}
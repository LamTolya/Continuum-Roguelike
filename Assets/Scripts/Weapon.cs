using UnityEngine;
using System;
using System.Collections.Generic;

public class Weapon : InteractableItem
{

    [SerializeField] private WeaponData WeaponData;

    [SerializeField] private int weaponDurability;
    protected GameObject trigger;

    public static event Action<int> WeaponUsed;
    public static event Action<WeaponData> WeaponEquipped;
    public static event Action WeaponSwapped;
    public static event Action<Weapon> WeaponInteracted;
    public static event Action WeaponDestroyed;

    [SerializeField]
    private bool WeaponEquiped = false;
    public override void Interact()
    {
        WeaponEquiped = true;
        WeaponData.HitBoxNavigation.colliderForm = WeaponData.HitBox;
        Wear();
    }

    private void OnEnable()
    {
        AttackingController.AttackFinished += UpdateDurability;

        if (gameObject.GetComponent<SpriteRenderer>() == null)
        {
            gameObject.AddComponent<SpriteRenderer>().sprite = WeaponData.ItemSprite;
        }
    }
    private void OnDisable()
    {
        WeaponEquiped = false;
        AttackingController.AttackFinished -= UpdateDurability;
    }
    public void Wear()
    {
        WeaponUsed?.Invoke(weaponDurability);
        WeaponInteracted?.Invoke(GetComponent<Weapon>());
        WeaponEquipped?.Invoke(WeaponData);
    }
    public void SetOff()
    {
        if (!WeaponData.Permanent)
        {
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
        WeaponEquiped = false;
        WeaponSwapped?.Invoke();
    }

    private void DestroyWeapon()
    {
        WeaponDestroyed?.Invoke();
        Destroy(gameObject);
    }

    private void UpdateDurability()
    {
        if (WeaponEquiped && !WeaponData.Permanent)
        {
            if (weaponDurability > 1)
            {
                Debug.Log("-1 dura");
                weaponDurability--;
                WeaponUsed?.Invoke(weaponDurability);
            }
            else
            {
                DestroyWeapon();
            }
        }
    }


}

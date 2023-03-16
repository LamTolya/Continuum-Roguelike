using UnityEngine;
using System;
using System.Collections.Generic;

public class Weapon : InteractableItem
{
    [SerializeField] private WeaponData WeaponData;

    [SerializeField] private int weaponDurability;
    protected GameObject trigger;

    public static event Action<int> WeaponUsed;
    public static event Action<Weapon> WeaponInteracted;
    public static event Action WeaponDestroyed;

    public override void Interact()
    {
        WeaponData.HitBoxNavigation.colliderForm = WeaponData.HitBox;
        enabled = true;
        Wear();
    }

    private void OnEnable()
    {
        AttackingController.AttackFinished += UpdateDurability;
    }
    void Start()
    {
        if (gameObject.GetComponent<SpriteRenderer>() == null)
        {
            gameObject.AddComponent<SpriteRenderer>().sprite = WeaponData.ItemSprite;
        }
        enabled = false;
    }
    private void OnDisable()
    {
        AttackingController.AttackFinished -= UpdateDurability;
    }
    public void Wear()
    {
        WeaponUsed?.Invoke(weaponDurability);
        WeaponInteracted?.Invoke(GetComponent<Weapon>());
    }

    public WeaponData GetWeaponData()
    {
        return WeaponData;
    }
    public void DestroyWeapon()
    {
        WeaponDestroyed?.Invoke();
        Destroy(gameObject);
    }

    private void UpdateDurability()
    {
        Debug.Log(WeaponData.Permanent);
        Debug.Log(weaponDurability + WeaponData.ItemName);
        if (!WeaponData.Permanent)
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

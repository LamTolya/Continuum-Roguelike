using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIWeaponDisplay: MonoBehaviour
{
    [SerializeField] private PlayerEquipments playerEquipments;
    [SerializeField] private Image weaponSprite;
    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private TextMeshProUGUI weaponDurability;

    float _weaponDurability;
  
    private void OnEnable()
    {
        Weapon.WeaponInteracted += UISetUp;
        Weapon.WeaponUsed += SetDurability;
    }

    private void OnDisable()
    {
        Weapon.WeaponInteracted -= UISetUp;
        Weapon.WeaponUsed -= SetDurability;
    }
    private void UISetUp(Weapon weapon)
    {
        SetColor();
        WeaponData weaponData = weapon.GetWeaponData();
        weaponName.text = weaponData.ItemName;
        weaponSprite.sprite = weaponData.ItemUISprite;
    }

    private void SetDurability(int durability)
    {
        _weaponDurability = durability;
        if(durability >= 0)
        {
            weaponDurability.text = durability.ToString();
        }
        else
        {
            weaponDurability.text = "inf.";
        }

        SetColor();


    }

    private void SetColor()
    {
        if (_weaponDurability < 3 && _weaponDurability > 0)
        {
            weaponDurability.color = new Color(256, 0, 0);
        }
        else
        {
            weaponDurability.color = new Color(1, 1, 1);
        }
    }
}


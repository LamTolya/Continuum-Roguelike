using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class UIWeaponDisplay: MonoBehaviour
{
    [SerializeField] private PlayerEquipments playerEquipments;
    [SerializeField] private Image weaponSprite;
    [SerializeField] private Image weaponSpriteBackground;
    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private TextMeshProUGUI weaponDurability;

    float _weaponDurability;
    float reload_cd;
  
    private void OnEnable()
    {
        Weapon.WeaponInteracted += UISetUp;
        Weapon.WeaponUsed += SetDurability;
        AttackingController.AttackFinished += Reload;
    }

    private void OnDisable()
    {
        Weapon.WeaponInteracted -= UISetUp;
        Weapon.WeaponUsed -= SetDurability;
        AttackingController.AttackFinished -= Reload;
    }


    void Reload()
    {
        weaponSpriteBackground.fillAmount = 1;
        StartCoroutine(CooldownAnimation());
    }

    IEnumerator CooldownAnimation()
    {
        float timeElapsed = 0;
        while(timeElapsed < reload_cd)
        {
            weaponSpriteBackground.fillAmount = Mathf.Lerp(1, 0, timeElapsed / reload_cd);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        weaponSpriteBackground.fillAmount = 0;

    }

    private void UISetUp(Weapon weapon)
    {
        SetColor();
        WeaponData weaponData = weapon.GetWeaponData();
        reload_cd = weaponData.ReloadTime;
        weaponName.text = weaponData.ItemName;
        weaponSprite.sprite = weaponData.ItemUISprite;
        weaponSpriteBackground.sprite = weaponData.ItemUISprite;
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


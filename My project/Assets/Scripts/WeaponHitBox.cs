using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class WeaponHitBox : MonoBehaviour
{
    public bool Permanent;
    public bool PlayerEquipped;

    private void OnEnable()
    {
        Weapon.WeaponDestroyed += Destruct;
        AttackingController.AttackFinished += PlayAnimation;
    }
    
    private void OnDisable()
    {
        Weapon.WeaponDestroyed -= Destruct;
        AttackingController.AttackFinished -= PlayAnimation;
    }

    private void PlayAnimation()
    {
        // add Animator later
        //gameObject.GetComponent<Animator>().SetTrigger("Attack");
    }


    private void Destruct()
    {
        if (!Permanent)
        {
            Destroy(gameObject);
            Debug.Log($"{gameObject.name} Hitbox is deleted");
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Assets/ Weapon", order = 4)]
public class WeaponData : ItemData
{
    public int WeaponDamage;
    public GameObject HitBox;
    public Navigation HitBoxNavigation;

    public List<BaseAction> WeaponMoves;

    [Header("Special Cases")]
    public bool Permanent;

}

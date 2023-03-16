using UnityEngine;
using System.Collections.Generic;

public class MeleeModule: AttackModule
{
    [SerializeField] private Enemy EnemyData;
    [SerializeField] private EnemyOnTriggerEntered DamageHitbox;

    public override void Attack()
    {
        base.Attack();
        DealDamage(DamageHitbox.Colliders);
    }
    // i could turn this loop off, if the distance of attack is not even close to function.
    // otherwise saying turn off most of functions, if the distance to attack is insufficient
    // 
    private void DealDamage(List<Collider> hitList)
    {
        foreach (Collider collider in hitList) 
        {
            collider.GetComponent<IDamageable>()?.TakeDamage(EnemyData.enemyDamage);
        }
    }
}








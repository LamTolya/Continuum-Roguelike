using UnityEngine;
using System.Collections.Generic;

public class AttackModule: MonoBehaviour
{
    [SerializeField] private Enemy EnemyData;
    [SerializeField] private EnemyOnTriggerEntered DamageHitbox;

    public void DealDamageInZone()
    {
        DealDamage(DamageHitbox.Colliders);
    }
    private void DealDamage(List<Collider> hitList)
    {
        foreach (Collider collider in hitList) 
        {
            collider.GetComponent<IDamageable>()?.TakeDamage(EnemyData.enemyDamage);
        }

       
    }
}









using UnityEngine;

public class AttackOnEntered: MonoBehaviour 
{
    float damage = 0.5f;
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IDamageable>()?.TakeDamage(damage);
    }
}







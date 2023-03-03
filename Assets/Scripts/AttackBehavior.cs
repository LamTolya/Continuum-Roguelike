using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AttackBehavior: MonoBehaviour
{
    [Header("Attack Stats")]
    [Range(0.5f, 10f)]
    [SerializeField] float AttackDelay;
    [SerializeField] float attackDistance;
    float distance;

    [Header("Required Components")]
    [SerializeField] protected Transform Player;
    [SerializeField] private AnimatorAttack AnimatorAttack;
    private Vector3 Target;
    IEnumerator AttackEvent()
    {
        while (true)
        {
            if (distance <= attackDistance) Attack();
            yield return new WaitForSeconds(AttackDelay);
        }
    }

    void Attack()
    {
        if (AnimatorAttack != null) AnimatorAttack.Animate();
    }
  
    private void OnEnable()
    {
        StartCoroutine(AttackEvent());
    }

    public Vector3 GetTarget()
    {
        return Target;
    }
  
}









using UnityEngine;

public class AnimatorAttack: MonoBehaviour
{
    [SerializeField] private Animator Animator;

    public void Animate()
    {
        if (Animator != null) Animator.SetTrigger("Attack");
    }
}





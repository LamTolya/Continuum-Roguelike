using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPointNotification : MonoBehaviour
{
    private Animator Animator;
    void OnEnable()
    {
        Enemy.EnemyDied += AddPoint;
    }

    private void OnDisable()
    {
        Enemy.EnemyDied -= AddPoint;
    }

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void AddPoint()
    {
        Animator.SetTrigger("Notify");
    }
}

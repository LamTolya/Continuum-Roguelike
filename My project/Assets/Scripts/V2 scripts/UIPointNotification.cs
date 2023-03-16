using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPointNotification : MonoBehaviour
{
    private Animator Animator;
    int totalComboPoint;
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
        //totalComboPoint += point
        Animator.SetTrigger("Notify");
        
    }
}

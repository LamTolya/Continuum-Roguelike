using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDamage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private Animator TextAnimator;
    private float InnerTimer;
    float backside;
    bool now;
    float totalDamage;

    private void OnEnable()
    {
        EnemyMessenger.DamageReceived += ShowDamage;
    }

    private void OnDisable()
    {
        EnemyMessenger.DamageReceived -= ShowDamage;
    }

    void Test()
    {
        Text.text = "";
        totalDamage = 0;
    }
    public void ShowDamage(float damage)
    {
        TextAnimator.Play("New State");
        TextAnimator.Play("UIDamage");
        totalDamage += damage;
        Text.text = totalDamage.ToString();
        Invoke(nameof(Test), 3f);
    }

}

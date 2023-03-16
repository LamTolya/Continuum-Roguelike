using UnityEngine;
using System;

public class EnemyMessenger: MonoBehaviour
{
    public static event Action<float> DamageReceived;

    public void SentDamage(float damage)
    {
        Debug.Log(damage);
        DamageReceived?.Invoke(damage);
    }
}

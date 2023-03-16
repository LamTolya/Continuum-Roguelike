using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Player Data", order = 3)]
public class PlayerData : ScriptableObject
{
    [NonSerialized] public float Health = 5;

    private float BaseHealth = 5;

    private void OnEnable()
    {
        Player.PlayerDied += ResetHealth;
    }

    private void OnDisable()
    {
        Player.PlayerDied -= ResetHealth;
    }

    void ResetHealth()
    {
        Health = BaseHealth;
    }


}

using UnityEngine;
using System;

public class LoadPlayer: MonoBehaviour
{
    [SerializeField] private Player Player;
    static public event Action<Player> PlayerLoaded;

    private void OnEnable()
    {
        WorldManager.NextWorldOn += SetPosition;
    }

    private void OnDisable()
    {
        WorldManager.NextWorldOn -= SetPosition;
    }

    void SetPosition()
    {
        Player.gameObject.transform.position = transform.position;
        PlayerLoaded?.Invoke(Player);
    }
}

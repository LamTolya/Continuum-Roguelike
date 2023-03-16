using UnityEngine;
using System;

public class LoadPosition : MonoBehaviour
{
    [SerializeField] private Player Player;
    static public event Action<Player> PlayerLoaded;
    private void Start()
    {
        SetPosition();
    }
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
        PlayerLoaded?.Invoke(Player);
    }
}

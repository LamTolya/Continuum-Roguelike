using UnityEngine;
using System;

public class MapBehaviour: MonoBehaviour
{
    public static event Action MapCleared;
    [SerializeField]
    private int EnemiesLeft;

    private void OnEnable()
    {
        WorldManager.NextWorldOn += DisableMap;
        Enemy.EnemyDied += MinusEnemyCount;
        Enemy.EnemySpawned += AddEnemyCount;
    }

    private void OnDisable()
    {
        WorldManager.NextWorldOn -= DisableMap;
        Enemy.EnemyDied -= MinusEnemyCount;
        Enemy.EnemySpawned -= AddEnemyCount;
    }

    private void Start()
    {
        if (EnemiesLeft == 0)
        {
            ActivateDoor();
        }
    }

    private void DisableMap()
    {
        gameObject.SetActive(false);
    }
    void AddEnemyCount()
    {
        Debug.Log("Enemy spawned");
        EnemiesLeft++;
    }


    void MinusEnemyCount()
    {
        EnemiesLeft--;
        if(EnemiesLeft == 0)
        {
            ActivateDoor();
        }
    }

    void ActivateDoor() {
        Debug.Log("World is Cleared");
        MapCleared?.Invoke();
    }
}


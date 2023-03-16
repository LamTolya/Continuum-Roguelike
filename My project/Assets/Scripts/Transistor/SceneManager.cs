using UnityEngine;
using System;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Scene StartScene;
    private Scene currentScene;
    [SerializeField] private Transform Player_Obj;
    [SerializeField] private Scene ResetScene;

    public static event Action PlayerReseted;
    public static event Action<Player> PlayerLoaded;
    // totalPoints


    private void Start()
    {
        currentScene = StartScene;
        LoadPlayer(currentScene);
    }

    private void OnEnable()
    {
        SceneDoor.DoorOpened += LoadPlayer;
        Player.PlayerDied += ResetPlayer;
        PlayerLoaded?.Invoke(Player_Obj.GetComponent<Player>());

    }
    private void OnDisable()
    {
        SceneDoor.DoorOpened -= LoadPlayer;
        Player.PlayerDied -= ResetPlayer;
    }

    private void LoadPlayer(Scene scene)
    {
        currentScene.gameObject.SetActive(false);
        currentScene = scene;
        if(scene.SceneStart != null)
        {
            Vector3 spawnPoint = scene.SceneStart.position;
            Vector3 spawn = new Vector3(spawnPoint.x, Player_Obj.position.y, spawnPoint.z);
            Player_Obj.position = spawn;
        }
        scene.gameObject.SetActive(true);
    }

    void ResetPlayer()
    {
        LoadPlayer(ResetScene);
        PlayerReseted?.Invoke();
    }
}


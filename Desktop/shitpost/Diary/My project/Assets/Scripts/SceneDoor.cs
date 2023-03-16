using UnityEngine;
using System;

public class SceneDoor: InteractableItem
{
    [SerializeField] Scene Scene;
    public static event Action<Scene> DoorOpened;
   
    public override void Interact()
    {
        UpdateDoor();
    }
    private void UpdateDoor()
    {
        DoorOpened?.Invoke(Scene);
        Debug.Log("Opening");
    }
    private void OnEnable()
    {
        MapBehaviour.MapCleared += EnableDoor;
        WorldManager.NextWorldOn += DisableDoor;
    }
    private void OnDisable()
    {
        MapBehaviour.MapCleared -= EnableDoor;
        WorldManager.NextWorldOn -= DisableDoor;
    }
    
    private void Start()
    {
        //DisableDoor();
    }

    private void EnableDoor()
    {
        gameObject.SetActive(true);
    }

    private void DisableDoor()
    {
        gameObject.SetActive(false);
    }
}

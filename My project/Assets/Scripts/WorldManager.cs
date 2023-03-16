using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class WorldManager: MonoBehaviour
{
    [SerializeField] private Scenary Scenary;
    [SerializeField] private int mapCount;
    [SerializeField] private List<GameObject> Maps;
    float maxMaps;

    public static event Action NextWorldOn;

    private void SetUp()
    {
        Maps = new List<GameObject>();
        maxMaps = Scenary.Maps.Count;
        foreach(GameObject map in Scenary.Maps)
        {
            var m = Instantiate(map);
            m.AddComponent<MapBehaviour>();
            m.SetActive(false);
            Maps.Add(m);
        }

        Maps[0].SetActive(true);    
    }

    private void OnEnable()
    {
        if (Scenary != null)
        {
            SetUp();
        }
        //SceneDoor.DoorOpened += LoadNextMap;
    }
    private void OnDisable()
    {
        //SceneDoor.DoorOpened -= LoadNextMap;
    }

    private void LoadNextMap()
    {
        mapCount++;
        NextWorldOn?.Invoke();
        if(mapCount < maxMaps)
        {
            Maps[mapCount].SetActive(true);
            Debug.Log("Load New Map");
        }
        else
        {
            Debug.LogError("no maps futher was implemented.");
        }
    }

}

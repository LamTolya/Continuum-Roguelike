using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Settings
{
    public KeyCode keycode;
    public float Volume;
    public float MouseSensitivity;
}

public class LifeManager: MonoBehaviour
{
    public void Destruct(GameObject gameObject, float health)
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
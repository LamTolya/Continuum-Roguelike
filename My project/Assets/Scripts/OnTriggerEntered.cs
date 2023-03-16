using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class OnTriggerEntered : MonoBehaviour
{
    public List<Collider> Colliders;
    public static event Action<List<Collider>> TriggerActivated;
    private void OnEnable()
    {
        TriggerEvent();
    }

    public virtual void TriggerEvent()
    {
        TriggerActivated?.Invoke(Colliders);
    }
    private void Awake()
    {
        Colliders = new List<Collider>();
    }

    private void OnDisable()
    {
        Colliders = new List<Collider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(Colliders.IndexOf(other) == -1)
        {
            Colliders.Add(other);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (Colliders.IndexOf(other) != -1)
        {
            Colliders.Remove(other);
        }
    }
    private void LateUpdate()
    {
        for (var i = 0; i < Colliders.Count; i++)
        {
            if(Colliders[i] == null)
            {
                Colliders.Remove(Colliders[i]);
            }
        }
    }
}

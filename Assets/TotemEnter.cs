using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TotemEnter : MonoBehaviour
{
    [SerializeField] private TotemData totem;
    public static event Action<TotemData> TotemEntered;
    public static event Action TotemExited;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            TotemEntered?.Invoke(totem);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TotemExited?.Invoke();
    }
    private void OnDisable()
    {
        TotemExited?.Invoke();
    }
}

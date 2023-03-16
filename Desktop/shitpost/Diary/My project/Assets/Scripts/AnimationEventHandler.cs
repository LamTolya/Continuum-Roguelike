using UnityEngine;
using System;
using UnityEngine.Events;

public class AnimationEventHandler: MonoBehaviour
{
    public UnityEvent EventEnded;

    public void OnEventEnded()
    {
        EventEnded?.Invoke();
    }


}





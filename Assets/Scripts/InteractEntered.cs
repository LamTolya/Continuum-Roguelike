using System.Collections.Generic;
using UnityEngine;

public class InteractEntered : OnTriggerEntered
{
    [SerializeField]
    private List<GameObject> interactables;
    public void Update()
    {
        for (var i = 0; i < Colliders.Count; i++)
        {
            if(Colliders[i].GetComponent<IInteractable>() != null)
            {
                interactables.Add(Colliders[i].gameObject);
            }
        }

    }
}
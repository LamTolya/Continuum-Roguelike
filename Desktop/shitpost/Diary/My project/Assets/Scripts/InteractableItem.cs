using UnityEngine;

public class InteractableItem: MonoBehaviour, IInteractable
{ 
    public virtual void Interact()
    {
        Debug.Log("interact with Item");
    }
 
}
using UnityEngine;
using UnityEngine.Events;
using System;
public class InteractController : MonoBehaviour
{
    InteractableItem closestInteractableItem = null;
    public void OnEnable()
    {
        PlayerInput.KeyEvent += Check;
        PlayerInput.EnviromentKeyEvent += EnviromentCheck;
    }
    private void OnDisable()
    {
        PlayerInput.KeyEvent -= Check;
        PlayerInput.EnviromentKeyEvent -= EnviromentCheck;
    }
    void EnviromentCheck()
    {
        Check();
    }
    void Check()
    {
        float closest = 3f;
        closestInteractableItem = null;

        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        foreach (var collider in colliders){
           if(collider.GetComponent<IInteractable>() != null)
            {
                var distance = Vector3.Distance(gameObject.transform.position, collider.gameObject.transform.position);
                if(distance < closest)
                {
                    closest = distance;
                    closestInteractableItem = collider.gameObject.GetComponent<InteractableItem>();
                }
            }
        }

        if (closestInteractableItem != null) closestInteractableItem.Interact();

    }


}

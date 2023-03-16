using UnityEngine;

[CreateAssetMenu(fileName = "Interact Input", menuName = "Player Data/ Interact Input")]

public class InteractTriggerInput: TriggerInput
{
    private void OnEnable()
    {
        InteractTriggerInput interactTrigger = CreateInstance<InteractTriggerInput>();
    }
}

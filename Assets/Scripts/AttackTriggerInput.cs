using UnityEngine;

[CreateAssetMenu(fileName = "Attack Input", menuName = "Player Data/ Attack Input")]
public class AttackTriggerInput: TriggerInput
{
    private void OnEnable()
    {
        AttackTriggerInput attackTrigger = CreateInstance<AttackTriggerInput>();
    }
}

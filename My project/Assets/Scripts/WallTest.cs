using UnityEngine;

public class WallTest: MonoBehaviour
{
    [SerializeField] private EnemyMovement controller;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            controller.BackTarget();
            Debug.Log("hit wall");
        }
    }
}

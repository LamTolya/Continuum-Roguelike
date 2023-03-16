using UnityEngine;

public class EnemyWallStop: MonoBehaviour
{
    RaycastHit hit;
    private EnemyMovement controller;
    
    private void Start()
    {
        controller = GetComponent<EnemyMovement>();
    }
    private void LateUpdate()
    {
        Check();
    }
    void Check()
    {
        Debug.DrawLine(transform.position, controller.Target);
        if (Physics.Raycast(transform.position, controller.Target, out hit, 0.1f))
        {
            if (hit.collider.gameObject.layer == 6)
            {
                controller.enabled = false;
                controller.UpdateTarget();
                controller.enabled = true;
            }
        }
    }
}

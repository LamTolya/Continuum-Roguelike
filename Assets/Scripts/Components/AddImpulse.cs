using UnityEngine;
using System.Collections;
public class AddImpulse: MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float Force = 2000f;
    public void AddForce(Vector3 host, float Force, float negative)
    {
        rb.freezeRotation = true;
        rb.useGravity = false;

        Vector3 direction = (host - gameObject.transform.position).normalized;
        Vector3 newdir = new Vector3(direction.x, 0f, direction.z);
    }

    private void DelayDrag()
    {
        rb.drag = 5;
    }
}

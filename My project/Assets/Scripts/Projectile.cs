using UnityEngine;
using System;
using System.Collections;
public class Projectile: MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Rigidbody rb;
    private float velocity;
    private Vector3 direction;
    float t;
    bool Activated = false;
    [SerializeField] float additionalDegrees;
    public void Fly(Vector3 Start, Vector3 Target)
    {
        
        transform.position = Start;
        targetPosition = Target;
        velocity = 8f;
        Activated = true;
        direction = (targetPosition - transform.position).normalized;
        ChangeAttackPosition();
        Activated = true;
        StartCoroutine(Ticking());
        Destroy(gameObject, 7f);
    }

    IEnumerator Ticking()
    {
        while (t < 1)
        {
            t += 0.03f;
            velocity = Mathf.Lerp(velocity, 0, t);
            yield return new WaitForSeconds(0.5f);
        }
       
    }
    private void ChangeAttackPosition()
    {
        float angle = AngleBetweenTwoPoints(transform.position, targetPosition);
        transform.rotation = Quaternion.Euler(new Vector3(90f, 0f, angle + additionalDegrees));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.z - b.z, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void LateUpdate()
    {
        if (!Activated) return;
        if (t >= 1) enabled = false;
        transform.position += direction * velocity * Time.deltaTime;
    }


}







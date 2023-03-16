using UnityEngine;

public class RotateAtPlayer: MonoBehaviour
{
    [Header("Required Components")]
    [SerializeField] protected Transform Player;
    [SerializeField] private AnimatorAttack AnimatorAttack;
    [SerializeField] float additionalDegrees;
    float distance;
    private void Update()
    {
        distance = (transform.position - Player.position).sqrMagnitude;
        ChangeAttackPosition();
    }

    public void ChangeAttackPosition()
    {
        float angle = AngleBetweenTwoPoints(transform.position, Player.position);
        transform.rotation = Quaternion.Euler(new Vector3(90f, 0f, angle + additionalDegrees));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.z - b.z, a.x - b.x) * Mathf.Rad2Deg;
    }

}









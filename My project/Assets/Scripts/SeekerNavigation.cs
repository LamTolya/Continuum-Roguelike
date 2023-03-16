using UnityEngine;
public class SeekerNavigation : MonoBehaviour, IAttackNavigation
{
    //[SerializeField] private Transform player;
    [SerializeField] private float offset;
    private float degreesMode = 90f;
    private Camera Camera;

    private void Start()
    {
        Camera = Camera.main;
    }
    private void FixedUpdate()
    {
        AttackNavigation();
    }

    public void AttackNavigation()
    {
        var halo = transform;
        Vector2 positionOnScreen = Camera.WorldToViewportPoint(halo.position);
        Vector2 mouseOnScreen = (Vector2)Camera.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        halo.rotation = Quaternion.Euler(new Vector3(degreesMode, 0f, angle));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

}




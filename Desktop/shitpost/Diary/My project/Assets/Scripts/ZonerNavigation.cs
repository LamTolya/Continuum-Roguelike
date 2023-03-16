using UnityEngine;

public class ZonerNavigation: MonoBehaviour, IAttackNavigation 
{
    [SerializeField] Vector3 worldPosition;
    [SerializeField] float offset;
    [SerializeField] float angleMode = 90f;

    Plane RayPlane = new Plane(Vector3.down, 0);

    private void Start()
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    private void Update()
    {
        AttackNavigation();
        transform.rotation = Quaternion.Euler(angleMode, 0f, 0f);
    }
    public void AttackNavigation()
    {
        var mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        if(RayPlane.Raycast(ray, out float distance))
        {
            worldPosition = ray.GetPoint(distance);
        }

        transform.position = new Vector3(worldPosition.x, worldPosition.y + offset, worldPosition.z);
    }
}


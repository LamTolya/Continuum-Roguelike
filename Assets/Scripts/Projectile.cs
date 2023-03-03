using UnityEngine;

public class Projectile: MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float velocity;
    private GameObject projectile;
    public Projectile(Vector3 startPos, Vector3 endPos, float speed, GameObject obj)
    {
        startPosition = startPos;
        targetPosition = endPos;
        velocity = speed;
        projectile = obj;
        
    }

    private void Start()
    {
        if (projectile != null)
        {
            GameObject obj = Instantiate(projectile);
            obj.transform.position = Vector3.MoveTowards(startPosition, targetPosition, velocity);
            Debug.Log("flying");
        }
       
    }
}









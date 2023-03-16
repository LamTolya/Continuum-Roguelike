using UnityEngine;

public class OnHitEntered: MonoBehaviour
{
    public bool CanBeAttacked;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>() != null)
        {
            CanBeAttacked = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            CanBeAttacked = true;
        }
    }

    private void OnDisable()
    {
        CanBeAttacked = false;
    }
}










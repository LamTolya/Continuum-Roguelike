using UnityEngine;

public class Shot: MonoBehaviour
{
    [SerializeField]
    private GameObject projectileObj;
    [SerializeField]
    private AttackBehavior AttackLead;

    public void Shotting()
    {
        if (projectileObj.GetComponent<Projectile>() == null) projectileObj.AddComponent<Projectile>();
        Projectile proj = projectileObj.GetComponent<Projectile>();
        proj = new Projectile(transform.position, AttackLead.GetTarget(), 3f, projectileObj);
    }

}









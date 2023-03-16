using UnityEngine;

public class RangeModule: AttackModule
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private AttackBehavior AttackBehavior;

    private void Shotting()
    {
        GameObject projectileObj = Instantiate(projectilePrefab);
        Projectile projectile = projectileObj.GetComponent<Projectile>();
        projectile.Fly(transform.position, AttackBehavior.GetTarget());
    }



    public override void Attack()
    {
        base.Attack();
        Shotting();
    }
}








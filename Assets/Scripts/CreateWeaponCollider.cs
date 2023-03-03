using UnityEngine;
using System;

public class CreateWeaponCollider: MonoBehaviour
{
    [SerializeField]
    private Navigation NavigationCheck;
    public static event Action<GameObject> TriggerCreated;

    private void OnEnable()
    {
        Weapon.WeaponInteracted += CreateColliderForm;
    }
    private void OnDisable()
    {
        Weapon.WeaponInteracted -= CreateColliderForm;
    }
    private void CreateColliderForm(Weapon weapon)
    {
        if (NavigationCheck.colliderForm!= null)
        {
            Debug.Log("create collider" + NavigationCheck.colliderForm.name);
            GameObject collider = Instantiate(NavigationCheck.colliderForm, transform);
            collider.transform.parent = gameObject.transform;
            collider.SetActive(true);
            collider.AddComponent<WeaponHitBox>();
            collider.AddComponent<OnTriggerEntered>();
            collider.AddComponent<Rigidbody>().useGravity = false;
            NavigationCheck.colliderForm = null;

            TriggerCreated?.Invoke(collider);
        }
    }
}

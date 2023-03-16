using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{

    [SerializeField] private List<GameObject> ListWeapons;
    [SerializeField] private Weapon CurrentWeapon;
    [SerializeField] private Weapon DefaultWeapon;

    void Set()
    {
        
    }

    public void WearWeapon()
    {
        if (CurrentWeapon == null)
        {
            SwapWeapon();
        }
        // give attack++
        // activate seeker
        // activate trigger
    }

    void SwapWeapon()
    {

    }
    private void Update()
    {
        Set();
    }

}

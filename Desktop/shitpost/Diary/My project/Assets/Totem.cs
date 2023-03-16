using UnityEngine;
using System;

public class Totem: InteractableItem
{
    [SerializeField] private TotemData TotemData;

    [SerializeField] private int DamageIncrease;
    [SerializeField] private int FavorIncrease;
    [SerializeField] private int DefenseIncrease;
    [SerializeField] private int SpeedIncrease;

    public static event Action<TotemData> TotemEquiped;

    public override void Interact()
    {
        base.Interact();
        TotemEquiped?.Invoke(TotemData);
        gameObject.SetActive(false);
    }

   
}






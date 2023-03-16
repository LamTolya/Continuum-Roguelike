using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TotemData", menuName = "Assets/ Totems", order = 4)]
public class TotemData : ScriptableObject
{
    public string Name;
    [TextArea]
    public string TotemDescription;
    public float DamageModifier;
    public float SpeedModifier;
    public float DefenseModifier;
    public float FavorModifier;
}






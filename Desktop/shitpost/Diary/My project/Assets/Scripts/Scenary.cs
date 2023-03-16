using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Normal Scenary", menuName = "Assets/Maps Scenary", order = 4)]
public class Scenary: ScriptableObject
{
    public List<GameObject> Maps;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects")]
public class WeaponScriptableObject : ScriptableObject
{
    public string WeaponName;

    public Vector3 pickPosition;
    public Vector3 pickRotation;
}

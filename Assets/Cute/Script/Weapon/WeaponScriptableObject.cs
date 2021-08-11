using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects")]
public class WeaponScriptableObject : ScriptableObject
{
    public string WeaponName;

    public Vector3 pickPosition;
    public Vector3 pickRotation;
    public float dropYposition;
    public Vector3 dropRotation;

    public enum WeaponType { Sword,Axe,Spear,Scythe,Box,CrossBow};
    public WeaponType weaponType = WeaponType.Sword;
    
}

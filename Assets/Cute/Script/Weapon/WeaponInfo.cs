using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    public WeaponScriptableObject weapon;

    public void OnGrab(){
        transform.localPosition = weapon.pickPosition;
        transform.localEulerAngles = weapon.pickRotation;
    }

    public void OnDrop(){

    }
}

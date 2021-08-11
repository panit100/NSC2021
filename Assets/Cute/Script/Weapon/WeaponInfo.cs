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

    public void OnDrop(GameObject Groundweapon){
        transform.localPosition = new Vector3(Groundweapon.transform.position.x,weapon.dropYposition,Groundweapon.transform.localPosition.z);
        
        transform.localEulerAngles = weapon.dropRotation;
    }
}

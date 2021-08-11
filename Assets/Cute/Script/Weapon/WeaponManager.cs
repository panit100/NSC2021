using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon{
    //Weapon type
    public enum WeaponType { Sword,Axe,Spear,Scythe,Box,CrossBow};
}

[System.Serializable]
public class WeaponCollider{
    public Weapon.WeaponType weaponType;
    public Collider collider;
}

public class WeaponManager : MonoBehaviour
{
    public Weapon.WeaponType currentType = Weapon.WeaponType.Sword;
    

    //Contain all attack area of weapon
    [Header("Collider")]
    public WeaponCollider[] weaponCollider;

    
    public GameObject hand;
    public WeaponInfo weapon;

    
    private void Start() {
        
    }
    
    void GrabWeapon(){
        weapon.transform.parent = hand.transform;

        weapon.OnGrab();
        weapon.GetComponent<Collider>().enabled = false;
        currentType = weapon.weapon.weaponType;
    }

    void DropWeapon(GameObject Groundweapon){
        weapon.transform.parent = null;
        weapon.OnDrop(Groundweapon);
        weapon.GetComponent<Collider>().enabled = true;
    }
    

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Weapon" && Input.GetKeyDown(KeyCode.F)){
            if(weapon != null){
                DropWeapon(other.gameObject);
            }

            weapon = other.GetComponent<WeaponInfo>();
            GrabWeapon();
        }
    }
}

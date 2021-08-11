using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //Weapon type
    public enum WeaponType { Sword,Axe,Spear,Scythe,Box,CrossBow};
    public WeaponType currentType = WeaponType.Sword;

    //Contain all attack area of weapon
    [Header("Collider")]
    public GameObject[] weaponCollider;

    
    public GameObject hand;
    public WeaponInfo weapon;

    
    private void Start() {
        
    }
    
    void GrabWeapon(){
        weapon.transform.parent = hand.transform;

        weapon.OnGrab();
        weapon.GetComponent<Collider>().enabled = false;
        //currentType = weapon.weapon.weaponType;
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

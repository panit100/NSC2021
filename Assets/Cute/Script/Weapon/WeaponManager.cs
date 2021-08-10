using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //Check which weapon player hold
    public enum test { style1,style2,style3};
    public test _test = test.style1;

    //Contain all attack area of weapon
    [Header("Collider")]
    public GameObject[] weaponCollider;

    
    public GameObject hand;
    public WeaponInfo weapon;

    
    private void Start() {
        weapon.transform.parent = hand.transform;

        weapon.OnGrab();
    }
    
    void DorpWeapon(){
    }

    void GetWeapon(){
        
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.F)){
            
        }
    }

}

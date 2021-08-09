using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public enum test { style1,style2,style3};
    public test _test = test.style1;

    [Header("Collider")]
    [SerializeField]
    Collider gettingColliider;
    [SerializeField]
    Collider attackCollider;

    Rigidbody rigidbody;
    [SerializeField]
    PlayerController_Cute mainParent;

    
    private void Start() {
        if(GetComponentInParent<PlayerController_Cute>() != null){
            mainParent = GetComponentInParent<PlayerController_Cute>();
        }

        rigidbody = GetComponent<Rigidbody>();
    }

    
    
    void DorpWeapon(){
            rigidbody.isKinematic = false;
            //attackCollider.enabled = false;
            gettingColliider.enabled = true;
            gameObject.transform.parent = null;
            mainParent = null; 
    }

    void GetWeapon(GameObject parent){
        rigidbody.isKinematic = true;
        //attackCollider.enabled = true;
        gettingColliider.enabled = false;
        transform.localRotation = Quaternion.Euler(0,0,0);
        transform.localPosition = new Vector3(0,0,0);
        mainParent = parent.GetComponent<PlayerController_Cute>();
        
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.F)){
            other.GetComponent<PlayerController_Cute>().currentWeapon.DorpWeapon();
            gameObject.transform.parent = other.GetComponent<PlayerController_Cute>().handObject.transform;
            GetWeapon(other.gameObject);
            other.GetComponent<PlayerController_Cute>().currentWeapon = this;
            
        }
    }

}

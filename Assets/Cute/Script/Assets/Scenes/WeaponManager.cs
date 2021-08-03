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
    PlayerController_Cute parent;
    GameObject playerObject;

    
    private void Start() {
        if(GetComponentInParent<PlayerController_Cute>() != null){
            parent = GetComponentInParent<PlayerController_Cute>();
        }
        

        // if(parent != null){
        //     gettingColliider.enabled = false;
        // }else{
        //     gettingColliider.enabled = true;
        // }

        rigidbody = GetComponent<Rigidbody>();
        
        playerObject = FindObjectOfType<PlayerController_Cute>().gameObject;

    }

    // private void Update() {
        
        
    //     transform.position = Vector3.zero;
        
        
    // }

    void DorpWeapon(){
            rigidbody.isKinematic = false;
            attackCollider.enabled = false;
            gettingColliider.enabled = true;
            gameObject.transform.parent = null; 
    }

    void GetWeapon(){
        rigidbody.isKinematic = true;
        attackCollider.enabled = true;
        gettingColliider.enabled = false;
        transform.localRotation = Quaternion.Euler(0,0,0);
        transform.localPosition = new Vector3(0,0,0);
        
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.F)){
            other.GetComponent<PlayerController_Cute>().currentWeapon.DorpWeapon();
            gameObject.transform.parent = playerObject.transform;
            GetWeapon();
            other.GetComponent<PlayerController_Cute>().currentWeapon = this;
            
        }
    }

}

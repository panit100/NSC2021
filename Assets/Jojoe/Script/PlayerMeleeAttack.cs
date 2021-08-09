using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    Collider attackCollider;
    int damage = 20;
    public float reloadTime = 2f;
    bool isReloading;
    // Start is called before the first frame update
    void Start()
    {
        attackCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Reload();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            Reload();
        }
        closeCollider();
    }

    void Attack(){
        if(Input.GetMouseButtonDown(0))
        {
            attackCollider.GetComponent<BoxCollider>().enabled = true;
            Debug.Log("Left");
        }
        else if(Input.GetMouseButtonDown(1))
        {
            attackCollider.GetComponent<BoxCollider>().enabled = true;
            Debug.Log("Right");
        }
    }

    void closeCollider(){
        if(Input.GetMouseButtonUp(0))
        {
            attackCollider.GetComponent<BoxCollider>().enabled = false;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            attackCollider.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider input)
    {
        if(input.tag == "Enemy" )
        {
            input.GetComponent<EnemyController>().attck(damage);
        }
    }

    void Reload(){
        if(isReloading == false){
            Attack();
            isReloading = true;
            StartCoroutine(ReloadAfterTime());
        }
    }

    IEnumerator ReloadAfterTime(){
        Debug.Log("Wait");
        yield return new WaitForSeconds(reloadTime);
        Debug.Log("Ready");
        isReloading = false;
    }
}

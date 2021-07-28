using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    bool openCollider = false;
    public float attackDuration = 3f;
    Collider attackCollider;
    int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        attackCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        closeCollider();
    }

    void Attack(){
        if(Input.GetMouseButtonDown(0))
        {
            openCollider = true;
            attackCollider.GetComponent<BoxCollider>().enabled = true;
            Debug.Log("Left");

            
        }
        else if(Input.GetMouseButtonDown(1))
        {
            openCollider = true;
            attackCollider.GetComponent<BoxCollider>().enabled = true;
            Debug.Log("Right");
        }
        else{}
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
        else{}
    }

    private void OnTriggerEnter(Collider input)
    {
        //List
        //for each do damage
        //clear list
        if(input.tag == "Enemy" )
        {
            input.GetComponent<EnemyController>().attck(damage);
        }
    }
}

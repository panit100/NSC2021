using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    void OnTriggerEnter(Collider input) {
        if(input.tag == "Enemy" ){
            input.GetComponent<EnemyController>().attck(damage);
        }

        if(input.tag == "Wall" ){
            Destroy(this.gameObject);
        }
    }
}

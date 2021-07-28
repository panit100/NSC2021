using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hp = 100;
    
    public void attck(int damage){
        hp -= damage;
    }
}

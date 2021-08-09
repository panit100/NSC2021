using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp;
    public HealthBar healthBar;

    void Start(){
        currentHp = maxHp;
        healthBar.SetMaxHealth(maxHp);
    }
    public void attck(int damage){
        currentHp -= damage;
        healthBar.SetHealth(currentHp);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    Bullet bullet;
    public Rigidbody bulletPrefab;
    public float bulletSpeed = 15f;
    public int bulletDamage = 10;
    public float reloadTime = 2f;
    bool isReloading;
    // Start is called before the first frame update
    void Start(){
        bullet = bulletPrefab.GetComponent<Bullet>();
    }

    // Update is called once per frame
    void Update(){
        bullet.damage = bulletDamage;
        if(Input.GetMouseButtonDown(0)){
            Reload();
        }
    }

    void Shoot(){
        Rigidbody bulletClone = (Rigidbody) Instantiate(bulletPrefab, transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed;
    }

    void Reload(){
        if(isReloading == false){
            Debug.Log("Fire!!!!!");
            Shoot();
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

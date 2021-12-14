using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Projectile;

    public float BulletSpeed = 5f;

    float fireRate = 1f;
    float nextFire = 0f;

    void FixedUpdate()
    {
        if (Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }
    void Shoot(){
        int randomVal = Random.Range(60, 120);
        Vector3 spread = new Vector3(0, 0, randomVal-90);
        GameObject Shot = Instantiate(Projectile, firePoint.position, Quaternion.Euler(firePoint.rotation.eulerAngles + spread));
        Rigidbody2D rb = Shot.GetComponent<Rigidbody2D>();
        rb.AddForce(Shot.transform.up * BulletSpeed, ForceMode2D.Impulse);
    }
}
    

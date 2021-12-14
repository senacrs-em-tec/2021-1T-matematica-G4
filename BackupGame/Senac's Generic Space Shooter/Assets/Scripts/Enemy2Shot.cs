using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Shot : MonoBehaviour
{
    
    public GameObject gun;

    public Transform firePoint;
    public GameObject Projectile;

    public float BulletSpeed = 10f;

    float fireRate = 1f;
    float nextFire = 0f;
    bool active;
    // Update is called once per frame
    void Start(){
        active = false;
    }
    void FixedUpdate()
    {
        Transform target = GameObject.FindGameObjectWithTag("character").GetComponent<Transform>();
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);

        if (Time.time > nextFire && active == true){
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }
    void Shoot(){
        GameObject Shot = Instantiate(Projectile, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = Shot.GetComponent<Rigidbody2D>();
        rb.AddForce(Shot.transform.up * BulletSpeed, ForceMode2D.Impulse);
    }
    
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.layer == 10){
            active = true;
        }
    }
    
}

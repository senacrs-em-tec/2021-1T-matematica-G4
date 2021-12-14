using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Projectile;

    public float BulletSpeed = 10f;

    float fireRate = 0.15f;
    float nextFire = 0f;

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }
    void OnCollisionEnter2D (Collision2D other){
        if(other.gameObject.layer == 16){
            fireRate = 0.05f;
            Invoke("ResetPowerUp", 10);
            
        }
    }
    void Shoot(){
        int randomVal = Random.Range(85, 95);
        Vector3 spread = new Vector3(0, 0, randomVal-90);
        GameObject Shot = Instantiate(Projectile, firePoint.position, Quaternion.Euler(firePoint.rotation.eulerAngles + spread));
        Rigidbody2D rb = Shot.GetComponent<Rigidbody2D>();
        rb.AddForce(Shot.transform.up * BulletSpeed, ForceMode2D.Impulse);
        TrailRenderer trail = Shot.GetComponent<TrailRenderer>();
        Color tColor = new Color (Random.value, 1, 1);
        trail.startColor = tColor;
        trail.endColor = tColor;
        if(fireRate == 0.05f){
            Color tColor2 = new Color (Random.Range(.5f, 1), 0, 0);
            trail.startColor = tColor2;
            trail.endColor = tColor2;
        }
    }
    void ResetPowerUp(){
        fireRate = 0.15f;
    }
}

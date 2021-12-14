using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public GameObject hitParticle;


    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.layer == 8 || other.gameObject.layer == 11 || other.gameObject.layer == 3){
            Destroy(gameObject);
            Instantiate(hitParticle, transform.position, transform.rotation);
        }
        
    }
}

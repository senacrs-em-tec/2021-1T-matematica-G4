using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletHit : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D other){
        if(other.gameObject.layer == 7){
            Destroy(gameObject);
        }
        if(other.gameObject.layer == 3){
            Destroy(gameObject);
        }
    }
}

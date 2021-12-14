using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    float speed = 0.5f;

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed *Time.deltaTime);
        transform.position = position;
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.layer == 7 || other.gameObject.layer == 12){
           Destroy(gameObject);
        }
    }
}

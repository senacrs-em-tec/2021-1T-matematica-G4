using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x - speed *Time.deltaTime, position.y);
        transform.position = position;
    }
    void OnCollisionEnter2D (Collision2D other){
        if(other.gameObject.layer == 14 || other.gameObject.layer == 7){
            Destroy(gameObject);
        }
    }
}

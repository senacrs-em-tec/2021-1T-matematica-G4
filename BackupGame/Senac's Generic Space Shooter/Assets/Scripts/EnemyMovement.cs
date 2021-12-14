using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float speed = 2f;

    GameObject scoreText;

    public Rigidbody2D rb;
    
    public int givingPoints = 100;
    public float health = 3f;
    public bool isDead = false;

    public GameObject drop;
    

    void Start(){
        scoreText = GameObject.FindGameObjectWithTag("ScoreHolder");
    }
    void FixedUpdate(){
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed *Time.deltaTime);
        transform.position = position;
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0, 0));

        if(transform.position.y < min.y){
            Destroy(gameObject);
        }
        if(health <= 0){
            isDead = true;
        }
        if(isDead == true){
            Death();
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.layer == 6){
            health -= 1;
        }
        if(other.gameObject.layer == 10){
            speed = 0f;
        }
    }
    void Death(){
        int randomVal = Random.Range(1,100);
        if(randomVal <= 10){
            Instantiate(drop, gameObject.transform.position, drop.transform.rotation);
        }
        Destroy(gameObject);
        float multiplier = scoreText.GetComponent<Score>().multiplier;
        scoreText.GetComponent<Score>().score += givingPoints * multiplier;
    }
}

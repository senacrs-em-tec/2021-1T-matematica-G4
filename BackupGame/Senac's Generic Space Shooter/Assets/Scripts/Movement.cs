using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{


    public float MoveSpeed = 5f;
    float health;

    public Text healthText;

    bool invincible;
    public BoxCollider2D collision; 
    GameObject scoreText;
    public Rigidbody2D rb;
    Vector2 movement;

    SpriteRenderer sprite;


    void Start(){
        sprite = GetComponent<SpriteRenderer>();
        invincible = false;
        health = 5;
        scoreText = GameObject.FindGameObjectWithTag("ScoreHolder");
    }

    void Update()
    {
        healthText.text = "" + health;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(health <= 0){
            Destroy(gameObject);
        }

        if(invincible == false){
            sprite.color = new Color32(90,171,255,255);
            collision.isTrigger = false;
        }else{
            sprite.color = new Color32(90,171,255,100);
            collision.isTrigger = true;
        }
    }
    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.layer == 15 && health < 5 && !invincible){
            health += .5f;
        }else if(other.gameObject.layer == 15 && health < 5 && invincible){
            health += 1;
        }
        if(other.gameObject.layer == 9 && !invincible || other.gameObject.layer == 8  && !invincible || other.gameObject.layer == 13  && !invincible){
            health -= 1;
            invincible = true;
            scoreText.GetComponent<Score>().multiplier = 1;
            Invoke("resetInvulnerability", 2);
        }
    }
    void resetInvulnerability(){
        invincible = false;
    }
}

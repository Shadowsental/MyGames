using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWolfScript : MonoBehaviour {

    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;
    float jump;
    int damage;
    public int health = 2;
    private float timer;
    private float attackTimer = 0.8f;
    private float hurtTimer = 0.3f;
    public EnemyAttackScript enemyAttack;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= hurtTimer) {
            sprite.color = Color.white;
        }
        timer += Time.deltaTime;
        if (timer >= attackTimer)
        {
            anim.SetBool("isAttacking", false);
        }
    }
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "PlayerKnife")
            {
                sprite.color = Color.red;
                timer = 0;
            }

            if (collision.tag == "PlayerBullet") {
                sprite.color = Color.red;
                timer = 0;
            }
            if (collision.tag == "Player")
            {
                anim.SetBool("isAttacking", true);
                EnemyAttackScript thisAttack = Instantiate<EnemyAttackScript>(enemyAttack, transform.position, transform.rotation);
                print(transform.position);
                timer = 0;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkScript : MonoBehaviour {

    public float walkSpeed = 1.0f;
    public float wallLeft = 0.0f;
    public float wallRight = 2.0f;
    float walkingDirection = 1.0f;
    Animator anim;
    Vector2 walkAmount;
    float timer;
    float originalX;
    SpriteRenderer sprite;

    void Start()
    {
        wallLeft = transform.position.x - 1f;
        wallRight = transform.position.x + 1f;
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x > wallRight)
        {
            sprite.flipX = false;
            walkingDirection = -1.0f;
        }
        else
            if (walkingDirection < 0.0f && transform.position.x <= wallLeft)
        {
            sprite.flipX = true;
            walkingDirection = 1.0f;
        }
        transform.Translate(walkAmount);
    }
}

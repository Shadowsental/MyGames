using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public float walkSpeed = 1.0f;
	public float wallLeft = 0.0f;
	public float wallRight = 5.0f;
	float walkingDirection = 1.0f;
	Animator anim;
	Vector2 walkAmount;
	float attackTimer = 0.8f;
	float timer;
	float originalX;
	SpriteRenderer sprite;
	public EnemyAttackScript enemyAttack;

	void Start()
	{
		wallLeft = transform.position.x - 2.5f;
		wallRight = transform.position.x + 2.5f;
		sprite = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
		if (walkingDirection > 0.0f && transform.position.x > wallRight) {
			sprite.flipX = false;
			walkingDirection = -1.0f;
		} else
			if (walkingDirection < 0.0f && transform.position.x <= wallLeft) {
			sprite.flipX = true;
				walkingDirection = 1.0f;
		}
		transform.Translate (walkAmount);

		timer += Time.deltaTime;
		if (timer >= attackTimer) {
			anim.SetBool ("isAttacking", false);
			walkSpeed = 1.0f;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player") {
			walkSpeed = 0;
			anim.SetBool ("isAttacking", true);
			EnemyAttackScript thisAttack = Instantiate<EnemyAttackScript>(enemyAttack, transform.position, transform.rotation);
			print (transform.position);
			timer = 0;
		}
	}
}
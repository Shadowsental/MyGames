using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public int damage;
	string ignore;

	private void Start()
	{
		ignore = transform.parent.tag;
		Destroy (gameObject, 0.1f);
	}

	private void Updte()
	{
		transform.position += new Vector3 (0, 0, 0001);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		print(collision);
		if(collision.tag  != ignore)
		{
			BossHealthScript health = collision.GetComponent<BossHealthScript>();
			if(health)
			{
				health.takeDamage(damage);
			}
            EnemyWolfScript enemyHealth = collision.GetComponent<EnemyWolfScript>();
            if(enemyHealth)
            {
                enemyHealth.takeDamage(damage);
            }
		}
	}
}
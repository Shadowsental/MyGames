using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	int bulletDamage = 3;

    private void OnTriggerEnter2D(Collider2D collision)
	{
		BossHealthScript health = collision.GetComponent<BossHealthScript> ();
		if (health) {
			health.takeDamage (bulletDamage);
			Destroy (gameObject);
		}
        EnemyWolfScript enemyHealth = collision.GetComponent<EnemyWolfScript>();
        if(enemyHealth)
        {
            enemyHealth.takeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
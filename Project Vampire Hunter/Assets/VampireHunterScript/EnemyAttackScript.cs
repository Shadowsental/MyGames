using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour {
	
	public int enemyDamage;
	string ignore;

	private void Start()
	{
        Destroy(gameObject, 0.1f);
    }

	private void Updte()
	{
		transform.position += new Vector3 (0, 0, 0001);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.tag == "Player") {
			collision.GetComponent<PlayerScript> ().TakeDamage (enemyDamage);
            Destroy(gameObject);
		}

	}
}

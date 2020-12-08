using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossHealthScript : MonoBehaviour {

	public int enemyHealth;
	public string sceneAtDeath;
	public GameObject deathEffect;
    public GameObject gunShotEffect;
	SpriteRenderer sprite;
	Animator animator;
	private float timer;
	private float hurtTimer = 0.2f;
	PlayerScript playerScript;



	// Use this for initialization
	void Start () {

		playerScript = GetComponent<PlayerScript> ();
		sprite = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		//hurtColor = GetComponent <Color> ();
	}

	void FixedUpdate()
	{
		timer += Time.deltaTime;
		if (timer >= hurtTimer) {
			sprite.color = Color.white;
		}
	}
			
	public void takeDamage(int damage)
	{
		enemyHealth -= damage;
		if (enemyHealth <= 0) 
		{
			Instantiate (deathEffect, transform.position, transform.rotation);
			Destroy (this.gameObject);
			SceneManager.LoadScene (sceneAtDeath);
		}
	}
		
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "PlayerKnife") {
			sprite.color = Color.red;
			timer = 0;
			Instantiate (deathEffect, transform.position, transform.rotation);
		}
        if (collision.tag == "PlayerBullet")
        {
            sprite.color = Color.red;
            timer = 0;
            Instantiate(gunShotEffect, transform.position, transform.rotation);
        }
			
	}

}
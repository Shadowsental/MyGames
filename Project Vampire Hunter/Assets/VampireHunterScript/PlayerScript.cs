using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	Rigidbody2D rb;
	Animator animator;
	SpriteRenderer sprite;
	public float moveSpeed = 2f;
	public float jumpPower = 4f;
	public float shootTimer = 1.07f;
	public PlayerAttack attack;
	public bool isAttacking;
	public bool hasAttacked;
	public float slashTimer = 0.04f;
	float passiveTime = 0.1f;
	public int bulletAmmo;
	public Text ammoText;
	int swordDamage = 20;
	private float timer;
	private float timer2;
	private float painTimer = 0.4f;
	private float hurtTimer;
	Vector2 castPoint;
	Vector2 castDir;
	public int maxHealth = 15;
	public int currentHealth;
	int attackDamage = 1;
	BossHealthScript enemyHealth;
	public GameObject bloodEffect;
    public GameObject bullet;
 

	bool onGround;
    internal bool flipX;

    void Start()
	{
		currentHealth = maxHealth;
		castPoint = new Vector2 (transform.position.x, transform.position.y);
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		sprite = GetComponent<SpriteRenderer> ();
		ammoText = GetComponent<Text> ();
		bulletAmmo = 4;
	}

	void FixedUpdate()
	{
		DoGroundCheck ();
		DoInput ();
		DoAttacking ();

		if(FireplaceScript.checkpoint)
		print (FireplaceScript.checkpoint.transform.position);

		timer += Time.deltaTime;
		if(timer >= shootTimer)
		{
			animator.SetBool ("isShooting", false);
			moveSpeed = 2;
			jumpPower = 4;
		}

		timer2 += Time.deltaTime;
		if(timer2 >= slashTimer)
		{
			animator.SetBool ("isSlashing", false);
		}

		if(transform.position.y < -7)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
			
			painTimer += Time.deltaTime;
			if(painTimer >= hurtTimer) 
		{
				sprite.color = Color.white;
		}

	}

    void Update()
    {
        if (sprite.flipX) castDir = new Vector2(-1, 0);
        else castDir = new Vector2(1, 0);
    }


	void DoGroundCheck()
	{
		Collider2D[] colliderList = Physics2D.OverlapBoxAll (transform.position, new Vector2 (0.5f, 0.5f), 0);
		foreach (Collider2D collider in colliderList) {
			if (collider.tag == "ground" && rb.velocity.y == 0) {
				onGround = true;
			}
		}
		if (onGround == true) {
			animator.SetBool ("isJumping", false);
		} else {
			animator.SetBool ("isJumping", true);
		}
	}

	void DoInput()
	{
		if (Input.GetAxis ("Horizontal") > 0) {
			rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
			animator.SetBool ("isWalking", true);
			sprite.flipX = false;
		}
		if (Input.GetAxis ("Horizontal") < 0) {
			rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);
			animator.SetBool ("isWalking", true);
			sprite.flipX = true;
		}
		if (Input.GetAxis ("Horizontal") == 0) {
			rb.velocity = new Vector2 (0, rb.velocity.y);
			animator.SetBool ("isWalking", false);
		}

		if (Input.GetButton ("Jump") && onGround && rb.velocity.y == 0) {
			rb.velocity = new Vector2 (rb.velocity.x, jumpPower);
			onGround = false;
			animator.SetBool ("isJumping", true);
				
		}
		if (Input.GetButton ("Fire2") && onGround) {
			Debug.Log ("isShooting");
			moveSpeed = 0;
			jumpPower = 0;
			animator.SetBool ("isShooting", true);
			timer = 0;
			bulletAmmo = bulletAmmo - 1;
			SetAmmoText ();

			if (bulletAmmo == 0) {
                ammoText.text = "Out of ammo";
			}				
		}
	}

	public void Shoot()
	{
        GameObject thisBullet;
        thisBullet = Instantiate<GameObject>(bullet);
        thisBullet.transform.position = new Vector2(transform.position.x, transform.position.y + 0.3f);
        Rigidbody2D rb2d = thisBullet.GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector3(10 * castDir.x, 0);
        Destroy(thisBullet, 10);
	}

	void DoAttacking()
	{
		if(isAttacking || hasAttacked)
		{
			timer2 += Time.fixedDeltaTime;
			if (timer2 >= slashTimer) {
				isAttacking = false;
				hasAttacked = true;
			}
			if(timer >= slashTimer + passiveTime)
			{
				hasAttacked = false;
			}
		}
		if (Input.GetButton ("Fire1") && !isAttacking && !hasAttacked) {
			Debug.Log ("isSlashing");
			isAttacking = true;
			timer2 = 0;
			PlayerAttack thisAttack = Instantiate<PlayerAttack>(attack, transform);
			if (sprite.flipX)
			{
				float x = thisAttack.transform.localPosition.x;
				float y = thisAttack.transform.localPosition.y;
				thisAttack.transform.localPosition = new Vector2(-x, y);
			}
		}
		animator.SetBool ("isSlashing", isAttacking);
	}

	void SetAmmoText()
	{
		ammoText.text = "Ammo: " + bulletAmmo.ToString ();
		if (bulletAmmo <= 0) {
			ammoText.text = "Out of ammo";
		}
	}

	void Attack(Collider2D collision)
	{
		BossHealthScript enemyHealth = collision.GetComponent<BossHealthScript> ();
		if (enemyHealth) {
			enemyHealth.takeDamage (swordDamage);
		}
	}

	void OnEnterTrigger2D(Collider2D collision)
	{
		if(collision.tag == "enemy")
		{
			currentHealth -= 1;
			sprite.color = Color.red;
			painTimer = 0;

			if (currentHealth <= 0) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}

        if(collision.tag == "fireplace")
        {
            currentHealth = maxHealth;
        }
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		Debug.Log ("woof");
		sprite.color = Color.red;
		painTimer = 0;

		if (currentHealth <= 0) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}
}
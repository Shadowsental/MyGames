using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

	public GameObject bullet;
    Vector2 castPoint;
    PlayerScript player;



    void Start()
    {
        castPoint = new Vector2(transform.position.x, transform.position.y + 0.5f);
        player = GetComponent<PlayerScript>();
   
    }

    public void Shoot()
	{
        GameObject thisBullet;
        thisBullet = Instantiate<GameObject>(bullet);
        thisBullet.transform.position = castPoint;
        Rigidbody2D rb = thisBullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(10, 0);
        Destroy(thisBullet, 10);

	}

}

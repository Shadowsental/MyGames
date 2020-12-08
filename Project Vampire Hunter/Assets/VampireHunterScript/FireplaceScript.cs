using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceScript : MonoBehaviour {

	public static FireplaceScript checkpoint; 


	void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log (collision);
		if (collision.tag == "Player")
		{
			GetComponent<Animator> ().SetBool ("isOnFire", true);
			checkpoint = this;
		}
	}
}
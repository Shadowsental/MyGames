using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTextScript : MonoBehaviour {

	Text text;
	GameObject hero;


	void Start()
	{
		text = GetComponent<Text> ();
		hero = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update()
	{
		int ammo;
		ammo = hero.GetComponent<PlayerScript>().bulletAmmo;
		text.text = "Ammo: " + ammo;
	}
}

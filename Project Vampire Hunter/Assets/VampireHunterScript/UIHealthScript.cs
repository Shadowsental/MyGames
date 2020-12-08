using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHealthScript : MonoBehaviour {

	Slider slider;
	PlayerScript health;

	public GameObject fill;

	void Start()
	{
		slider = GetComponent<Slider> ();
		GameObject hero = GameObject.FindGameObjectWithTag ("Player");
		health = hero.GetComponent<PlayerScript> ();
	}

	void Update()
	{
		slider.value = (float)health.currentHealth / (float)health.maxHealth;
	}
}
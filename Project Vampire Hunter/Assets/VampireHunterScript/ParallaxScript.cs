using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour {

	public float scrollX;
	public float scrollY;
	GameObject mainCamera;
	float startX;
	float startY;

	void Start()
	{
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		startX = transform.position.x;
		startY = transform.position.y;
	}

	void Update()
	{
		float newX = startX + mainCamera.transform.position.x * (1 - scrollX);
		float newY = startY + mainCamera.transform.position.y * (1 - scrollY);
		transform.position = new Vector2 (newX, newY);
	}


}
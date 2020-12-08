using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class BartAndersConvoScript : MonoBehaviour
{
	public GameObject guiObject;

	void Start()
	{
		guiObject.SetActive (false);
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			guiObject.SetActive(true);
		}
	}

	void OnTriggerExit2D()
	{
		guiObject.SetActive (false);
	}
}
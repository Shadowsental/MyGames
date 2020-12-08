using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseOverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

	public GameObject textGUI;

	void Start()
	{
		textGUI.SetActive (false); 
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log ("mausa!!");
		textGUI.SetActive (true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log ("Rip mouse.");
		textGUI.SetActive (false);
	}

}
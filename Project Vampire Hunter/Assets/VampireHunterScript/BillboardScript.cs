using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BillboardScript : MonoBehaviour {


	public Button werewolf;
	public Button Rturn;
	public string town;
	public string bar;

	// Use this for initialization
	void Start()
	{
		Button wrf = werewolf.GetComponent<Button> ();
		Button rtrn = Rturn.GetComponent<Button> ();
		wrf.onClick.AddListener (werewolfStage);
		rtrn.onClick.AddListener (returnToBar);
	}

	// Update is called once per frame
	void werewolfStage() {
		SceneManager.LoadScene(town);
	}

	void returnToBar()
	{
		SceneManager.LoadScene(bar);
	}
}

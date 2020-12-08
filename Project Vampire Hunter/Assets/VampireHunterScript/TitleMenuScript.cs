using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMenuScript : MonoBehaviour {


	public Button startGame;
	public Button endGame;
	public Button controls;
	public Button credits;
	public string levelToLoad;
	public string controlToLoad;
	public string creditToLoad;

	void Start()
	{
		Button btn = startGame.GetComponent<Button> ();
		Button ctrl = controls.GetComponent<Button> ();
		Button end = endGame.GetComponent<Button> ();
		Button crd = credits.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
		ctrl.onClick.AddListener (TaskControl);
		end.onClick.AddListener (EndGameOnClick);
		crd.onClick.AddListener (TaskCredits);
	}

	void TaskOnClick()
	{
		SceneManager.LoadScene (levelToLoad);
	}

	void TaskControl()
	{
		SceneManager.LoadScene (controlToLoad);
	}

	void TaskCredits()
	{
		SceneManager.LoadScene (creditToLoad);
	}

	void EndGameOnClick()
	{
		Application.Quit ();
	}
}
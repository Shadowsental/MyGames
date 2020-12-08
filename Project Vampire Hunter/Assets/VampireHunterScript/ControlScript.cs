using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlScript : MonoBehaviour {

	public Button returnScene;
	public string sceneReturn;

	// Use this for initialization
	void Start () {

		Button rtn = returnScene.GetComponent<Button> ();
		rtn.onClick.AddListener (OnTaskReturn);

	}
	
	// Update is called once per frame
	void OnTaskReturn () {
		SceneManager.LoadScene (sceneReturn);
	}
}

using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {

	public void gameExit() {
		Application.Quit(); 
	}
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.LoadLevel("MainMenu"); 
	}
}

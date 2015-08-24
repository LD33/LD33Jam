using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public void GoToMenu(){
		Application.LoadLevel("MainMenu");
	}

	public void PlayGame(){
		Application.LoadLevel("Monster1");
	}


	void Update () {
	
	}
}

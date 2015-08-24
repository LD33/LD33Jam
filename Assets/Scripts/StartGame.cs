using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	public GameObject StartUI;
	public GameObject PanelStart;
	void Awake(){
		Time.timeScale =0;
	}
	

	void StartGameAccept(){
		if(Input.GetButtonDown ("Jump")){
			GameObject.Find ("GameManager").GetComponent<GameManager> ().enabled = true;
			StartUI.SetActive(true);
			PanelStart.SetActive(false);
			Time.timeScale =1;
			GameObject.Find ("GameManager").GetComponent<StartGame> ().enabled = false;
		}
	}

	void Update () {
		StartGameAccept ();
	}
}

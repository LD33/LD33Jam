using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public Text TimeText;
	public Text ScoreText;
	private float startTime;
	private float ellapsedTime;
	float min;
	float sec;
	float Score;
	// Use this for initialization
	void Awake(){
		startTime = Time.time;
	}

	public void GetScore(){
		Score +=10;
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		ellapsedTime = Time.time - startTime;
		min = Mathf.Floor((ellapsedTime/60f));
		sec = (ellapsedTime % 60f);


		//TimeText.text = "Time " + min.ToString("0")+ ":" + sec.ToString("00");
		TimeText.text = "Time " + min.ToString("0")+":" + sec.ToString("00");
		ScoreText.text = "Score: " + Score.ToString("0000");
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public Text TimeText;
	public Text ScoreText;
	public Text ComboCount;
	public Text ComboX2;
	private float startTime;
	public float ellapsedTime;
	float CountTime;
	public float CountTimeValor;
	float CountCombo;
	public float GetScoreValor = 10;
	public float GetScoreValor1 = 10;
	public float GetScoreCombo = 20;
	bool ComboOn = false;
	bool Combox2 = false;
	float min;
	float sec;
	float Score;

	//Monster life
	public int life;

	// Use this for initialization
	void Awake(){
		startTime = Time.time;
		life = 6; //initial life
	}

	public void GetScore(){
		Score +=GetScoreValor;
		CountTime = 2;
		CountCombo += 1;
	}

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		CountTime1 ();
		CountCombo1 ();
		ComboText ();

		ellapsedTime = Time.time - startTime;
		min = Mathf.Floor((ellapsedTime/60f));
		sec = (ellapsedTime % 60f);


		//TimeText.text = "Time " + min.ToString("0")+ ":" + sec.ToString("00");
		TimeText.text = "Time " + min.ToString("0")+":" + sec.ToString("00");
		ScoreText.text = "Score: " + Score.ToString("0000");
	}

	void CountTime1(){
		if(CountTime > 0){
			CountTime -= Time.deltaTime;
		}
		
		if (CountTime <= 0) {
			CountCombo=0;
			GetScoreValor = GetScoreValor1;
			ComboOn = false;
			Combox2 = false;
		}
	}
	void CountCombo1(){
		if(CountCombo >=5){
			ComboOn = true;
		}
		
		if(CountCombo >=10){
			GetScoreValor = GetScoreCombo;
			Combox2 = true;
		}
	}
	
	void ComboText(){
		if (ComboOn) {
			ComboCount.text = "Combo  " + CountCombo;
			if (Combox2) {
				ComboX2.text = "X2";
			}
		} 
		if (ComboOn == false) {
			ComboCount.text = "";
			ComboX2.text = "";
		}
	}

}

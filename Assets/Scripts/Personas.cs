using UnityEngine;
using System.Collections;

public class Personas : MonoBehaviour {
	public GameObject Player;
	float DistanceMonster1;
	public float DistanceMonster;
	public float VelX;
	public float VelXRun;
	public int RandomN;

	void Start () {
		RandomN = Random.Range (1, 3);
	}


	void Update () {

		DistanceMonster1 = Player.transform.position.x - gameObject.transform.position.x;
		MovStart ();
		MovRun ();


	}


	void MovStart(){
		
		if (RandomN == 1) {
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (VelX, 0);
		}
		if (RandomN == 2) {
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-VelX, 0);
		}
	}
	
	void MovRun(){
		if(DistanceMonster1<DistanceMonster){
			if(0<DistanceMonster1){
				VelX = VelXRun;
				RandomN =2;
			}
		}
		
		if(DistanceMonster1>(-DistanceMonster)){
			if(0>DistanceMonster1){
				VelX = VelXRun;
				RandomN =1;
			}
			
		}
		
	}


	void OnTriggerEnter2D(Collider2D hitcheck) {
		if (hitcheck.tag == "Ignore") {
			Physics2D.IgnoreCollision (GetComponent<Collider2D> (), hitcheck.GetComponent<Collider2D> ());
			
		}
	}



}

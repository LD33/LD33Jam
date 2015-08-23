using UnityEngine;
using System.Collections;

public class SpawnP : MonoBehaviour {
	public float TimeToSpawn;
	public float TimeToSpawn2;
	public float TimeToSpawn3;
	public float TimeToDestroy;
	public Rigidbody2D Rayo;
	public float TimeCompareFase1;
	public float TimeCompareFase2;
	float TimeElapsed;
	bool Spawning = true;
	//public float Impulso;

	
	void Start () {
		//tirarrayos();
	}
	
	IEnumerator Wait1() {
		yield return new WaitForSeconds (TimeToSpawn);
		
		Spawning = true;
		
	}
	
	void Update () {
		TimeElapsed = GameObject.Find("GameManager").GetComponent<GameManager>().ellapsedTime;
		if(TimeElapsed >TimeCompareFase1){
			TimeToSpawn = TimeToSpawn2;
		}
		if(TimeElapsed >TimeCompareFase2){
			TimeToSpawn2 = TimeToSpawn3;
		}

		if (Spawning){
			WaitAndSpawn ();
		}

	}
	
	void WaitAndSpawn () {
		Rigidbody2D NewSpawn;

		NewSpawn = Instantiate (Rayo, gameObject.transform.position, Quaternion.identity) as Rigidbody2D;

		NewSpawn.gameObject.SetActive(true);
		Destroy (NewSpawn.gameObject, TimeToDestroy);
		Spawning = false;
		StartCoroutine(Wait1());
	}
	
	/*void tirarrayos(){
		InvokeRepeating ("WaitAndSpawn", 0, TimeToSpawn);
	}*/
}

using UnityEngine;
using System.Collections;

public class SpawnP : MonoBehaviour {
	public float TimeToSpawn;
	public float TimeToDestroy;
	public Rigidbody2D Rayo;

	//public float Impulso;

	
	void Start () {
		tirarrayos();
	}
	
	
	
	void Update () {
		
	}
	
	void WaitAndSpawn () {
		Rigidbody2D NewSpawn;
		
		NewSpawn = Instantiate (Rayo, gameObject.transform.position, Quaternion.identity) as Rigidbody2D;

		NewSpawn.gameObject.SetActive(true);
		Destroy (NewSpawn.gameObject, TimeToDestroy);
		
	}
	
	void tirarrayos(){
		InvokeRepeating ("WaitAndSpawn", 0, TimeToSpawn);
	}
}

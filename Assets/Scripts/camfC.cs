using UnityEngine;
using System.Collections;



public class camfC : MonoBehaviour {

	public GameObject Target;
	public float zposition;
	public float yposition;
	public Vector3 position1;
	public float Smooth;

	void Update(){

		//position1 = new Vector3 (Target.transform.position.x, yposition,zposition);
		//gameObject.transform.position = Vector3.Lerp (transform.position,position1,Time.deltaTime*Smooth);

		gameObject.transform.position = new Vector3 (Target.transform.position.x, yposition,zposition);
		/*if (gameObject.transform.position.x <= 2.5) {
			gameObject.transform.position = new Vector3 (2.5f,yposition,zposition);
		}

		if (gameObject.transform.position.x >= 161) {
			gameObject.transform.position = new Vector3 (161,yposition,zposition);
		}*/
	}


}
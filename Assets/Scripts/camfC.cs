using UnityEngine;
using System.Collections;



public class camfC : MonoBehaviour {

	public GameObject Target;
	public float zposition;
	public float yposition;
	public Vector3 position1;
	public float Smooth;
	public float LeftLimit;
	public float RightLimit;

	void Update(){

		//position1 = new Vector3 (Target.transform.position.x, yposition,zposition);
		//gameObject.transform.position = Vector3.Lerp (transform.position,position1,Time.deltaTime*Smooth);

		gameObject.transform.position = new Vector3 (Target.transform.position.x, yposition,zposition);
		if (gameObject.transform.position.x <= LeftLimit) {
			gameObject.transform.position = new Vector3 (LeftLimit,yposition,zposition);
		}

		if (gameObject.transform.position.x >= RightLimit) {
			gameObject.transform.position = new Vector3 (RightLimit,yposition,zposition);
		}
	}


}
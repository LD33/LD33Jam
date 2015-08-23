using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour 	
{
	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator> ();

	}
	void OnTriggerEnter2D (Collider2D hitcheck)
	{
		if (hitcheck.name == "Monster")
		{
			GameObject.Find("GameManager").GetComponent<GameManager>().life -= 1;
			Debug.Log (GameObject.Find("GameManager").GetComponent<GameManager>().life);
			animator.SetBool("exploded",true);
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
	}

}

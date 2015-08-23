using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour 	
{
	public bool exploded = false;

	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator> ();

	}
	void OnTriggerEnter2D (Collider2D hitcheck)
	{
		if (hitcheck.name == "Monster")
		{	
			exploded = true;
			GameObject.Find("GameManager").GetComponent<GameManager>().life -= 1;
			GameObject.Find("Monster").GetComponent<PlayerMov>().Hurt();
			Debug.Log (GameObject.Find("GameManager").GetComponent<GameManager>().life);

			gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
	}

	void Update(){
		animator.SetBool("exploded",exploded);
	}

}

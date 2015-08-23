using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	internal Animator animator;
	//bool IsGrounded = true;
	//public float Velx;
	bool isMoving;
	bool isHurt;
	//public GameObject player1;
	//public float Esperar;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();

//		TouchOn1 = GameObject.Find("Button").GetComponent<Button11>("touchcube");
		//animator.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		isHurt = GameObject.Find ("Monster").GetComponent<PlayerMov> ().isHurt;
		//isMoving = GetComponent<PlayerMov>().isMoving;

	}

	void FixedUpdate(){
		//animator.SetFloat ("Velx",Velx);
		//animator.SetBool ("IsGrounded",Position.isGrounded);
		//animator.SetBool ("isMoving",isMoving);
		animator.SetBool ("isHurt",isHurt);
		//	animator.SetFloat ("Esperar1",Esperar);
	}
}

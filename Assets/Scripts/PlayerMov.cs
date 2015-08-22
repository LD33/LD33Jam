using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour {
public float speed = 20;
float horizontalAxis;
Vector3 scaleX;
public bool isMoving;
float playerX;
float playerY;
public float jumpForce = 5;
	public static bool isHurt = false;
	public LayerMask groundMovPlataform;
	float VelocityEnY;


	public void KillEnemy(){
		VelocityEnY = Mathf.Abs(gameObject.GetComponent<Rigidbody2D> ().velocity.y);
		/*if (gameObject.GetComponent<Rigidbody2D> ().velocity.y <5) {
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 20),ForceMode2D.Impulse);
		}
		else */
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, VelocityEnY*1.4f+5),ForceMode2D.Impulse);
	}


	public void HurtL(){
		GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0f),ForceMode2D.Impulse);
	}

	public void HurtR(){
		GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0f),ForceMode2D.Impulse);
	}


	void movePlayer(){

		if (Input.GetButtonDown ("Jump")) {
			if (Position.isGrounded){
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
			}


		}
		if (Input.GetAxis ("Horizontal") != 0) {	
			isMoving = true;
			horizontalAxis = speed * Input.GetAxis ("Horizontal");
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (horizontalAxis, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
			//FlipSprite ();
		}
		 else 
			isMoving = false;
	}

	void FlipSprite(){

		scaleX = transform.localScale;
		if (Input.GetAxis("Horizontal") > 0)
		{
			scaleX.x = 1;
			transform.localScale = scaleX;
		}
		else if (Input.GetAxis("Horizontal") < 0)
		{
			scaleX.x = -1;
			transform.localScale = scaleX;
		}

	
	}

	public void Wait1(){
		StartCoroutine(Wait());
	}

	IEnumerator Wait() {
		yield return new WaitForSeconds (1.5f);
		PlayerMov.isHurt = false;
	}


	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.transform.tag == "MovingPlataform") 
		{
			transform.parent = coll.transform;
		}
	}

	// Update is called once per frame
	void Update () {
		if(isHurt == false){
			movePlayer ();
		}
		if(!Position.isGrounded){ 
			transform.parent = null;
		}
		Debug.Log (GetComponent<Rigidbody2D> ().velocity.y);

	}
}

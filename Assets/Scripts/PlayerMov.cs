using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour {
public float speed = 20;
public float speedRun = 20;
private float speed1;
float horizontalAxis;
Vector3 scaleX;
public bool isMoving;
public bool isRuning = false;
float playerX;
float playerY;
public float jumpForce = 5;
	public float dashForce = 3;
	public bool isHurt = false;
	public bool isDashing = false;
	public float dashActiveMov;
	public LayerMask groundMovPlataform;
	float VelocityEnY;
	float VelocityEnX;

	public void KillEnemy(){
		VelocityEnY = Mathf.Abs(gameObject.GetComponent<Rigidbody2D> ().velocity.y);
		/*if (gameObject.GetComponent<Rigidbody2D> ().velocity.y <5) {
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 20),ForceMode2D.Impulse);
		}
		else */
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, VelocityEnY*1.4f+5),ForceMode2D.Impulse);
	}


	public void Hurt(){
		isHurt = true;
		isDashing = true;
		StartCoroutine(Wait());
		StartCoroutine(WaitHurt());
		GetComponent<Rigidbody2D>().AddForce(new Vector2(-VelocityEnX/2, 0f),ForceMode2D.Impulse);
	}
	

	void movePlayer(){

		if (Input.GetButtonDown ("Jump")) {
			if (Position.isGrounded){
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
			}


		}
		if (Input.GetAxis ("Horizontal") != 0) {	
			isMoving = true;
			horizontalAxis = speed1 * Input.GetAxis ("Horizontal");
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (horizontalAxis, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
			//FlipSprite ();
		}
		else 
			isMoving = false;


		if (Input.GetButtonDown ("Fire1")){
			isDashing = true;
			if(VelocityEnX>0){
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(dashForce, 0f),ForceMode2D.Impulse);
			}
			if(VelocityEnX<0){
				gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
				GetComponent<Rigidbody2D>().AddForce(new Vector2(-dashForce, 0f),ForceMode2D.Impulse);
			}
			StartCoroutine(WaitDash());
		}
		if (Input.GetButton ("Fire2")) {
			isRuning = true;
			
		}
		else 
			isRuning = false;

		 
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
	

	IEnumerator Wait() {
		yield return new WaitForSeconds (1.5f);
		isHurt = false;
	}

	IEnumerator WaitDash() {
		yield return new WaitForSeconds (dashActiveMov);
		isDashing = false;
	}
	IEnumerator WaitHurt() {
		yield return new WaitForSeconds (1f);
		isDashing = false;
	}

	IEnumerator StartFixGame() {
		yield return new WaitForSeconds (0.1f);
		isDashing = false;
	}


	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.transform.tag == "MovingPlataform") 
		{
			transform.parent = coll.transform;
		}
	}

	void Start(){
		isDashing = true;
		StartCoroutine(StartFixGame());
	}
	void Update () {

		VelocityEnX = GetComponent<Rigidbody2D> ().velocity.x;

		if(isDashing == false){
			movePlayer ();
		}

		if(isRuning){
			speed1 = speedRun;
		}
		if(isRuning==false){
			speed1 = speed;
		}

		if(!Position.isGrounded){ 
			transform.parent = null;
		}
		//Debug.Log (VelocityEnX);

	}
}

using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {
public GameObject player;
public static bool isGrounded;
public LayerMask groundLayer;

	void Transformpos () {
		gameObject.transform.position = new Vector2 (player.transform.position.x, player.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		Transformpos ();
		isGrounded = Physics2D.IsTouchingLayers(GetComponent<Collider2D>(),groundLayer);

	}
}

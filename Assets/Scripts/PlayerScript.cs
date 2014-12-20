using UnityEngine;
using System.Collections;

/**
 * Unterschiedliche Groesse von Player1 und 2
 * 	-> 
 * Ventilator
 * Laufband
 * Lift
 * Domino mit Trigger am Ende
 * Webcam Input: Detect Red Blob
 * 
 **/
 public class PlayerScript : MonoBehaviour {

	public float speed = 10;

	public LayerMask groundMask;
	public Transform groundCheck1;
	public Transform groundCheck2;

	private float groundCheckRadius = 0.1f;
	private bool grounded = false;
	private bool facingLeft = true;

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck1.position, groundCheckRadius, groundMask) 
			|| Physics2D.OverlapCircle (groundCheck2.position, groundCheckRadius, groundMask);
		if (grounded) {
			float moveX = Input.GetAxis ("Horizontal-" + gameObject.name);
			if (moveX > 0 && facingLeft) {
				flip ();
			} else if (moveX < 0 && !facingLeft) {
				flip ();
			}
			if (rigidbody2D.velocity.x < 0.10 && rigidbody2D.velocity.x > -0.10) {
				moveX=moveX * 10;
			}
			rigidbody2D.AddForce (new Vector2 (moveX, 0) * speed);
			float dir = 1;
			if (facingLeft)	dir = -1;

			bool jump = Input.GetButton("Jump-" + gameObject.name);
			if (jump) {
				rigidbody2D.AddForce(new Vector2(10 * dir, 30) * speed);
			}
		}
	}
	private void flip() {
		facingLeft = ! facingLeft;
		rigidbody2D.transform.Rotate (new Vector3(0, 180, 0));
	}
}

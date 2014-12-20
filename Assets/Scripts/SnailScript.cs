using UnityEngine;
using System.Collections;

public class SnailScript : MonoBehaviour {
	public LayerMask groundMask;
	public Transform groundCheck1;
	public Transform groundCheck2;
	
	private float groundCheckRadius = 0.1f;
	private bool grounded = false;

	private bool facingLeft = true;

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck1.position, groundCheckRadius, groundMask) 
			|| Physics2D.OverlapCircle (groundCheck2.position, groundCheckRadius, groundMask);
		if (!grounded)
						return;

		float dir = 1;
		if (!facingLeft) {
			dir = -1;
		}
		rigidbody2D.AddForce (new Vector2(15 * dir, 0));
	}

	void OnCollisionEnter2D (Collision2D other) {
		//print (other);
		//print (other.collider);
		//print (other.contacts [0].otherCollider.shapeCount);
		//print (other.contacts [0].collider + ":" + other.contacts [0].otherCollider);
		//print (other.contacts [0].point + ":" + other.contacts.Length);
		//flip ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		flip ();
	}

	private void flip() {
		facingLeft = ! facingLeft;
		transform.Rotate (new Vector3(0, 180, 0));
	}
}

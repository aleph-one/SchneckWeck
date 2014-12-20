using UnityEngine;
using System.Collections;

public class SpringScript : MonoBehaviour {

	public float multiplier = 50;

	void OnCollisionEnter2D (Collision2D other) {
//		print (other);
//		print(other.collider);
//		print (other.gameObject);
//		print("This:" + other.contacts[0].collider);
//		print("Other:" +other.contacts[0].otherCollider.tag);
		//Vector2 v = transform.InverseTransformPoint (other.contacts[0].);
		if (other.gameObject.tag == "Player" && other.contacts[0].otherCollider is EdgeCollider2D)
			other.collider.attachedRigidbody.AddForce (new Vector2 (0, multiplier * other.rigidbody.mass) * other.relativeVelocity.magnitude);
	}
	void OnTriggerEnter2D(Collider2D other) {
		//Rigidbody2D b = other.gameObject.GetComponent<Rigidbody2D>();
		//print (b);

		//b.AddForce (new Vector2 (0, multiplier * b.mass * b.velocity.magnitude));
	}
}

using UnityEngine;
using System.Collections;

public class HeavyScript : MonoBehaviour {

	IEnumerator Squash() {
		for (int i = 0; i < 10; i++) {
			//transform.rotation.Set(f, 0, 0, 0);
			//transform.localRotation = new Quaternion(f, 0, 0, 1);
			transform.Rotate (new Vector3(8f, 0f, 0f));
			print ("Coroutine: " + i);
			yield return new WaitForSeconds(.02f);
		}
		for (int i = 0; i < 10; i++) {
			//transform.rotation.Set(f, 0, 0, 0);
			//transform.localRotation = new Quaternion(f, 0, 0, 1);
			transform.Rotate (new Vector3(-8f, 0f, 0f));
			print ("Coroutine: " + i);
			yield return new WaitForSeconds(.02f);
		}
		for (float f = 0f; f <= 40; f += 1) {
			GetComponent<Rigidbody2D>().AddForce (new Vector2(40, 0));
		}
	}
	
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			print(other.relativeVelocity + ":" + other.relativeVelocity.magnitude);
			//audio.Play();
			//StartCoroutine("Squash");
			//StartCoroutine("RunAway");
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {

		}
	}
}

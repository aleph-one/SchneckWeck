using UnityEngine;
using System.Collections;

public class MonsterScript : MonoBehaviour {

	public bool roaming = false;
	private bool facingLeft = true;

	void FixedUpdate () {
		if (roaming) {
			float dir = 1;
			if (!facingLeft) {
					dir = -1;
			}
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (14 * dir, 0));
		}
	}

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
			yield return new WaitForSeconds(.01f);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Bomb") {
			GetComponent<AudioSource>().Play();
			StartCoroutine("Squash");
			//StartCoroutine("RunAway");
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		//print ("Enter: " + other.tag);
		if (other.gameObject.tag != "Trigger")
			flip ();
	}

	private void flip() {
		facingLeft = ! facingLeft;
		//rigidbody2D.transform.Rotate (new Vector3(0, 180, 0));
		transform.Rotate (new Vector3(0, 180, 0));
		
		
	}
}

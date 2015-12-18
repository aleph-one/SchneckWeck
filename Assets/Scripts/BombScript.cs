using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {

	public float radius = 10f;
	public float forceMultiplier = 500f;
	public AudioClip boom;

	void OnActivate() {
		Collider2D[] enemies = Physics2D.OverlapCircleAll (transform.position, radius);//, 1 << LayerMask.NameToLayer("Enemies"));
		
		foreach(Collider2D en in enemies) {
			Rigidbody2D rb = en.GetComponent<Rigidbody2D>();
			if(rb != null) {
				Vector3 deltaPos = rb.transform.position - transform.position;
				Vector3 force = deltaPos.normalized * forceMultiplier;
				rb.AddForce(force);
			}
		}
		AudioSource.PlayClipAtPoint(boom, transform.position);
		
		Destroy (this.gameObject);
	}

	void PressurePlateEnter() {
		OnActivate ();
	}
}

using UnityEngine;
using System.Collections;

public class LiftScript : MonoBehaviour {
	
	public float height = 0.4f;
	public bool vertical = true;

	private bool activated = false;
	private Vector3 slide;
	private int dir = -1;
	
	// Use this for initialization
	void Start () {
		if (!vertical) {
			slide = new Vector3 (height, 0, 0);
		} else {
			slide = new Vector3 (0, height, 0);
		}
	}

	IEnumerator Animate() {
		for (int i = 0; i < 10; i++) {
			transform.position += slide * dir;
			print ("Coroutine: " + i);
			yield return new WaitForSeconds(.1f);
		}
		activated = false;
	}

	void PressurePlateEnter() {
		if (!activated) {
			activated = true;
			dir = dir * -1;
			StartCoroutine("Animate");
		}
	}
	
	void PressurePlateExit() {
		if (activated) {
			//activated = false;
			//dir = -1;
			//StartCoroutine("Animate");
		}
	}
}

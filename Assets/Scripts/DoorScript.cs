using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public bool reverse = false;
	public bool stayOpen = false;

	private bool activated = false;
	private Vector3 slide;

	// Use this for initialization
	void Start () {
		if (transform.rotation.z == 0) {
			slide = new Vector3 (1, 0, 0);
			slide *= ((BoxCollider2D)collider2D).bounds.size.x;
		} else {//if (transform.rotation.z == 90) {
			slide = new Vector3 (0, 1, 0);
			slide *= ((BoxCollider2D)collider2D).bounds.size.y;
//		} else {
//			print ("Unknown rotation: " + transform.rotation.z);
		}
		//print ("dfgfdg: " + ((BoxCollider2D)collider2D).bounds.size.y);

		if (reverse) {
			slide = slide * -1;
		}
	}

	void PressurePlateEnter() {
		if (!activated) {
			transform.position += slide;
			activated = true;
		}
	}

	void PressurePlateExit() {
		if (! stayOpen) {
			if (activated) {
				transform.position -= slide;
				activated = false;
			}
		}
	}
}

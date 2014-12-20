using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PressurePlate : MonoBehaviour {

	public List<Behaviour> triggers;
	private int count = 0;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Monster" || other.gameObject.tag == "Weight") {
			if (count == 0) {
				transform.localScale -= new Vector3(0f, 0.1f, 0f);
				transform.localPosition -= new Vector3(0f, 0.1f, 0f);
				for(int i=0; i<triggers.Count; i++) {
					triggers[i].SendMessage("PressurePlateEnter");
				}
			}
			count++;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Monster") {
			if (count == 1) {
				transform.localScale += new Vector3(0f, 0.1f, 0f);
				transform.localPosition += new Vector3(0f, 0.1f, 0f);
				for(int i=0; i<triggers.Count; i++) {
					triggers[i].SendMessage("PressurePlateExit");
				}
			}
			count--;
		}
	}
}

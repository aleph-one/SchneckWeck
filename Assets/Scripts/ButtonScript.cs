using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	void OnMouseDown() {
		transform.localScale -= new Vector3 (0.1f, 0.1f, 0.0f);
	}

	void OnMouseUp() {
		transform.localScale += new Vector3 (0.1f, 0.1f, 0.0f);
	}

	void PressurePlateEnter() {
		//print ("PressurePlateEnter");
	}
}

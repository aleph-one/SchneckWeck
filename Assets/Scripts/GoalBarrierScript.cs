using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoalBarrierScript : MonoBehaviour {

	public List<GameObject> objects;
	private List<GameObject> actualObjects;

	public int count = 0;

	void Start () {
		actualObjects = objects;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (actualObjects.Contains (other.gameObject)) {
			actualObjects.Remove(other.gameObject);
		}
		if (actualObjects.Count == count) {
			GameControllerScript.singleton.NextLevel ();
		}
		Destroy (other.gameObject);
	}
}

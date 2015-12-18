using UnityEngine;
using System.Collections;

public class DeathBarrierScript : MonoBehaviour {

	public AudioClip audioClip;
	private GameObject player;

	IEnumerator Mampf() {
		for (int i = 0; i < 3; i++) {
			//transform.localScale.Scale(new Vector3(1.1f, 1.2f, 1.1f));
			//transform.localScale.Set(1.2f, 1.2f, 1.2f);
			transform.localScale += new Vector3(0.2f, 0.1f, 0.1f);
			//player.transform.Rotate (new Vector3(0f, 8f, 0f));
			yield return new WaitForSeconds (.05f);
		}
		for (int i = 0; i < 3; i++) {
			transform.localScale -= new Vector3(0.2f, 0.1f, 0.1f);
			player.transform.localScale -= new Vector3(0.4f, 0.4f, 0.4f);
			yield return new WaitForSeconds (.1f);
		}
		Destroy (player);
	}
	private void collision(GameObject player) {
		if (player.tag == "Player") {
			this.player = player;
			GameControllerScript.singleton.RestartLevel();
			StartCoroutine("Mampf");
			if (audioClip != null)
				GetComponent<AudioSource>().PlayOneShot(audioClip);
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		collision (other.gameObject);
	}

	void OnCollisionEnter2D(Collision2D other) {
		collision (other.gameObject);
	}
}

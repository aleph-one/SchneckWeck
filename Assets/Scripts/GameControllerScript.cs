using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {
	public static GameControllerScript singleton;
	public GameObject gameOver;
	public GameObject gameWon;
	public GameObject pressKey;
	public GameObject levelText;
	public AudioClip gameWonAudio;
	public AudioClip gameOverAudio;

	bool isGameOver = false;
	static int level = 0;
	string key;
	int timer;

	void Awake() {
		if (singleton == null)
			singleton = this;
		else if(singleton != this)
			Destroy (gameObject);
		GUIText txt = levelText.GetComponent<GUIText>();
		txt.text = "Level " + (level + 1);
	}

	void Update() {
		if (isGameOver && Input.GetKey(key)) {
			Application.LoadLevel(level);		
		} else if (Input.GetKey(KeyCode.Escape)) {
			RestartLevel();
		}
	}

	void FixedUpdate() {
		if (timer > 40) {
			levelText.SetActive(false);
		}
		timer ++;
	}
	public void NextLevel() {
		if (! isGameOver) {
			audio.PlayOneShot (gameWonAudio);
			gameWon.SetActive (true);
			isGameOver = true;
			level++;
			pressRandomKey ();
		}
	}

	public void RestartLevel() {
		if (! isGameOver) {
			audio.PlayOneShot (gameOverAudio);
			gameOver.SetActive (true);
			isGameOver = true;
			pressRandomKey ();
		}
	}

	private void pressRandomKey() {
		GUIText txt = pressKey.GetComponent<GUIText>();
		int c = Random.Range (0, 26);
		char c2 = (char)(c + (int)'a');
		key = "" + c2;
		txt.text = "Press Key: " + key.ToUpper();
		
		pressKey.SetActive (true);
	}
}

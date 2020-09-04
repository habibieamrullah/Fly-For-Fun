using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public Text msgText;
	public Text textScore;
	public Text textMissiles;
	int highScore;
	bool highscoring = false;

	public static int currentScore = 0;
	public static int health = 100;
	public static int missiles = 10;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll();
		/*
		if (!PlayerPrefs.HasKey ("highscore")) {
			PlayerPrefs.SetInt ("highscore", 0);
		}
		*/
		highScore = PlayerPrefs.GetInt ("highscore");
		health = 100;
		missiles = 10;
		currentScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (health > 100)
			health = 100;
		if (health <= 0) {
			if (ZKAd.interstitial.IsLoaded ()) {
				ZKAd.interstitial.Show ();
			}
			SceneManager.LoadScene ("Crashed");
		}
		textScore.text = "Health: " + health + "%\nScore: " + currentScore + "\nHigh Score: " + highScore;
		textMissiles.text = "Guns: Unlimited\nMissiles: " + missiles;
		if (currentScore > highScore) {
			highScore = currentScore;
			PlayerPrefs.SetInt ("highscore", highScore);

			if(!highscoring)
				StartCoroutine(alertHs());

			highscoring = true;
		}
	}

	IEnumerator alertHs() {
		yield return new WaitForSeconds(1);
		Text xText = Instantiate (msgText) as Text;
		xText.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
		xText.text = "NEW HIGH SCORE";
	}
}

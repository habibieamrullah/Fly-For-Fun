using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void toMain(){
		SceneManager.LoadScene ("Main");
	}

	public void toSky(){
		SceneManager.LoadScene ("Sky");
	}

	public void toAbout(){
		SceneManager.LoadScene ("About");
	}

	public void showRVid(){
		if (ZKAd.rewardBasedVideo.IsLoaded()) {
			ZKAd.rewardBasedVideo.Show();
		}
	}
}

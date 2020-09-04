using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PilotCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "sparkable") {
			if (ZKAd.interstitial.IsLoaded ()) {
				ZKAd.interstitial.Show ();
			}
			SceneManager.LoadScene ("Crashed");
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDestroyer : MonoBehaviour {

	float timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += 1.0f * Time.deltaTime;
		if (timer > 3f) {
			GameObject.Destroy (gameObject);
		}
	}
}

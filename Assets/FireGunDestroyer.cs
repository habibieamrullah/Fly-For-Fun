using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGunDestroyer : MonoBehaviour {

	float timer = 0;
	public GameObject exp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += 1.0f * Time.deltaTime;
		if (timer > 3) {
			jeger();
		}

	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "sparkable") {
			jeger();
		}
	}

	public void jeger(){
		GameObject spark = Instantiate (exp) as GameObject;
		spark.transform.position = transform.position;
		GameObject.Destroy (spark, 3);
		GameObject.Destroy (gameObject);
	}
}

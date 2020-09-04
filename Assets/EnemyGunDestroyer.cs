using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunDestroyer : MonoBehaviour {

	float timer = 0;
	public GameObject exp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += 1.0f * Time.deltaTime;
		if (timer > 3) {
			GameObject.Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "sparkable") {
			mbledos (0);
		}
		if (col.gameObject.tag == "Player") {
			ScoreManager.health -= 1;
			mbledos (1);
		}
	}

	public void mbledos(int n){
		if (n == 1) {
			GameObject spark = Instantiate (exp) as GameObject;
			spark.transform.position = transform.position;
			GameObject.Destroy (spark, 3);
		}
		GameObject.Destroy (gameObject);
	}
}

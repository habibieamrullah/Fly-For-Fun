using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtGDestroyer : MonoBehaviour {

	float timer = 0;
	public GameObject exp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += 1.0f * Time.deltaTime;
		if (timer > 20) {
			jeger ();
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "sparkable" || col.gameObject.tag == "jetweapon1" || col.gameObject.tag == "enemybody") {
			jeger ();
		}
	}

	public void jeger(){
		GameObject spark = Instantiate (exp) as GameObject;
		spark.transform.position = transform.position;
		GameObject.Destroy (spark, 3);
		GameObject.Destroy (gameObject);
	}
}

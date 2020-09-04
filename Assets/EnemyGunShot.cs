using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunShot : MonoBehaviour {

	public GameObject enemyGun;
	public GameObject enemyalive;
	public Transform enemyShootPoint; 
	public Transform enemyBody;

	float timer = 0;
	bool isfiring = false;
	bool canfire = false;
	Transform pilotbody;

	// Use this for initialization
	void Start () {
		pilotbody = GameObject.FindGameObjectWithTag ("PlayerWeakSpot").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isfiring) {
			timer += Time.deltaTime;
			if (timer > 0.75f) {
				if(canfire && enemyalive.tag == "enemybody")
					isfiring = true;
			}
		} else {
			enemyShootPoint.transform.LookAt (pilotbody);
			GameObject gf = Instantiate (enemyGun, enemyShootPoint.position, enemyShootPoint.rotation) as GameObject;
			Rigidbody rb = gf.GetComponent<Rigidbody> ();
			rb.velocity = (pilotbody.position-rb.position).normalized * 500f;
			isfiring = false;
			timer = 0;
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			canfire = true;
			if (enemyBody.transform.localScale.x < 5f) {
				canfire = false;
			}
		}
	}
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			canfire = false;
		}
	}
}

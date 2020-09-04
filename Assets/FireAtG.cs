using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtG : MonoBehaviour {

	public GameObject gfPrefab;
	public Transform shootPoint;
	bool canFire = true;
	float timer = 0;
	bool fgpressed = false;

	// Update is called once per frame
	void Update () {
		if (ScoreManager.missiles > 0) {
			if (!canFire) {
				timer += Time.deltaTime;
				if (timer > 1f) {
					canFire = true;
					ScoreManager.missiles -= 1;
				}
			} else {
				if (fgpressed) {
					GameObject gf = Instantiate (gfPrefab) as GameObject;
					gf.transform.position = new Vector3 ((shootPoint.transform.position.x - .5f) + Random.Range (0f, 1f), (shootPoint.transform.position.y - 2f) + Random.Range (0f, 1f), (shootPoint.transform.position.z - .5f) + Random.Range (0f, 1f));
					gf.transform.rotation = shootPoint.transform.rotation;
					Rigidbody rb = gf.GetComponent<Rigidbody> ();
					rb.velocity = transform.forward * 100;
					canFire = false;
					timer = 0;
				}
			}
		}


		if (Input.GetKey (KeyCode.Space)) {
			fgpressed = true;
		} else if (Input.GetKeyUp (KeyCode.Space)) {
			fgpressed = false;
		}
		
	}

	public void openfire(){
		fgpressed = true;
	}

	public void stopfire(){
		fgpressed = false;
	}
}

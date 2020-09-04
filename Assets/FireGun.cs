using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour {

	public GameObject gfPrefab;
	public Transform shootPoint;
	bool canFire = true;
	float timer = 0;
	bool fgpressed = false;
	
	// Update is called once per frame
	void Update () {
		if (fgpressed) {
			if (!canFire) {
				timer += Time.deltaTime;
				if (timer > 0.1f) {
					canFire = true;
				}
			} else {
				GameObject gf = Instantiate (gfPrefab) as GameObject;
				gf.transform.position = new Vector3 ((shootPoint.transform.position.x - .5f) + Random.Range (0f, 1f), (shootPoint.transform.position.y - .5f) + Random.Range (0f, 1f), (shootPoint.transform.position.z - .5f) + Random.Range (0f, 1f));
				gf.transform.rotation = shootPoint.transform.rotation;
				Rigidbody rb = gf.GetComponent<Rigidbody> ();
				rb.velocity = transform.forward * 400;
				canFire = false;
				timer = 0;
			}
		}

		if (Input.GetKey (KeyCode.LeftControl)) {
			fgpressed = true;
		} else if (Input.GetKeyUp (KeyCode.LeftControl)) {
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

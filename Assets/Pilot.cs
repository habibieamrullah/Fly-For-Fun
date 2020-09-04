using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : MonoBehaviour {

	public float thrust;
	public int topSpeed;
	public Rigidbody rb;

	bool slideleft = false;
	bool slideright = false;

	float updownIn;
	float leftrightIn;

	void Start () {
		rb.transform.position = new Vector3 (Random.Range(-6000f, 2000f), 390, Random.Range(-300f, -2500f));
		rb = GetComponent<Rigidbody> ();

		updownIn = Input.acceleration.z;
		leftrightIn = Input.acceleration.x;
	}

	void LateUpdate() {
		if (rb.velocity.magnitude < topSpeed) {
			rb.AddRelativeForce (new Vector3 (0, 0, thrust));
		}


		
		if (Input.GetKey ("up")) {
			rb.AddRelativeTorque (new Vector3 (0.01f, 0, 0));
		}
		if(Input.GetKey ("down")){
			rb.AddRelativeTorque (new Vector3 (-0.01f, 0, 0));
		}
		if(Input.GetKey ("left")){
			rb.AddRelativeTorque (new Vector3 (0, 0, 0.1f));
		}
		if(Input.GetKey ("right")){
			rb.AddRelativeTorque (new Vector3 (0, 0, -0.1f));
		}
		if (Input.GetKey (KeyCode.A)) {
			rb.AddRelativeTorque (new Vector3 (0, -0.01f, 0));
		}
		if (Input.GetKey (KeyCode.D)) {
			rb.AddRelativeTorque (new Vector3 (0, 0.01f, 0));
		}


		float updown = Input.acceleration.z - updownIn;
		float leftright = Input.acceleration.x - leftrightIn;

		float slide = 0f;
		if (slideleft)
			slide = -0.01f;
		if (slideright)
			slide = 0.01f;

		rb.AddRelativeTorque (new Vector3((-updown * .01f) * 2, slide, (-leftright * 0.1f) * 2));

	}

	public void sl(int n){
		if (n == 0) {
			slideleft = false;
			slideright = false;
		}
		if (n == 1) {
			slideleft = true;
			slideright = false;
		}
		if (n == 2) {
			slideleft = false;
			slideright = true;
		}
	}
		
}

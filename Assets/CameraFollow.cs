using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public Transform pilot;
	public float smoothspeed = 1f;
	public Vector3 offset;

	void LateUpdate(){
		Vector3 dp = target.position + offset;
		Vector3 sp = Vector3.Lerp (transform.position, dp, smoothspeed);
		transform.position = sp;
		transform.LookAt (target);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {

	public Transform jet;

	public void LateUpdate(){
		Vector3 newPos = jet.position;
		newPos.y = transform.position.y;
		transform.position = newPos;
		transform.rotation = Quaternion.Euler (90f, jet.eulerAngles.y, 0f);
	}

}

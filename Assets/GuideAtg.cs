using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideAtg : MonoBehaviour {

	GameObject target;
	float timer = 0;
	bool targetFound = false;


	// Use this for initialization
	void Start () {

	}

	
	// Update is called once per frame
	void LateUpdate () {
		timer += Time.deltaTime;
		if (timer > 1.5f) {
			if (!targetFound) {
				target = FindClosest ();
			}
		}
		if (targetFound) {
			Vector3 shotTarget = new Vector3 (target.transform.position.x, target.transform.position.y + 5f, target.transform.position.z);
			float step = 50 * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, shotTarget, step);
		}

	}


	public GameObject FindClosest(){
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("enemybody");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach(GameObject go in gos){
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if(curDistance < distance){
				closest = go;
				distance = curDistance;
				targetFound = true;
			}
		}
		return closest;
	}

}

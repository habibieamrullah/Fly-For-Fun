using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParachuteScript : MonoBehaviour {

	public GameObject parachute;
	public Text msgText;
	bool isalive = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			if (isalive) {
				isalive = false;
				parachute.transform.localScale = new Vector3(0f, 0f, 0f);
				ScoreManager.missiles += 10;
				StartCoroutine(comeAgain ());
				Text xText = Instantiate (msgText) as Text;
				xText.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
				xText.text = "+10 MISSILE";
			}
		}
	}

	IEnumerator comeAgain()
	{
		yield return new WaitForSeconds(120);
		parachute.transform.localScale = new Vector3(7f, 7f, 7f);
		isalive = true;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	public Text msgText;
	public int inihealth;
	public float inicountdown;
	public GameObject enemyObj;
	public GameObject rt;
	public GameObject enemyExp;
	int health;
	float countDown = 20f;
	bool destroyed = false;
	public static bool enemyisdead = false;

	// Use this for initialization
	void Start () {
		health = inihealth;
		countDown = inicountdown;
	}
	
	// Update is called once per frame
	void Update () {
		if (destroyed) {
			if (countDown > 0f)
				countDown -= Time.deltaTime;
			else
				comeAgain ();
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "jetweapon1") {
			health -= 1;
			mbledug ();
		} else if (col.tag == "jetweapon2") {
			health -= 3;
			mbledug ();
		} else if (col.tag == "msensor") {
			enemyObj.tag = "enemybody";
		} 
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "msensor") {
			enemyObj.tag = "sparkable";
		}
	}

	public void mbledug(){
		if (health <= 0) {
			rt.transform.localScale = new Vector3 (0f, 0f, 0f);
			destroyed = true;
			GameObject exp = Instantiate (enemyExp) as GameObject;
			exp.transform.position = transform.position;
			GameObject.Destroy (exp, 4);
			enemyObj.transform.position = new Vector3(enemyObj.transform.position.x, enemyObj.transform.position.y - 500f, enemyObj.transform.position.z);
			enemyObj.tag = "sparkable";
			ScoreManager.currentScore += 10;
			enemyisdead = true;

			Text xText = Instantiate (msgText) as Text;
			xText.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
			xText.text = "+10 SCORE";

			/*
			Text msgtext = Instantiate (Resources.Load ("MsgText", typeof(Text))) as Text;
			msgtext.text = "+10 SCORE";


			Text newMsg = Instantiate (msgText, new Vector2(0, 0), new Vector2(0, 0)) as Text;
			newMsg.text = "+10 SCORE";
			*/
		}
	}

	public void comeAgain()
	{
		rt.transform.localScale = new Vector3 (.7f, .7f, .7f);
		enemyObj.transform.position = new Vector3(enemyObj.transform.position.x, enemyObj.transform.position.y + 500f, enemyObj.transform.position.z);
		enemyObj.tag = "enemybody";
		health = inihealth;
		destroyed = false;
		countDown = inicountdown;
		enemyisdead = false;
	}
}

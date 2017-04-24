using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controls boss life

public class BossVariables : MonoBehaviour {

	private int life;
	private bool hitable;
	public Text lifeBoss;

	public Animator animBoss;

	public GameObject wonText;
	public Text countDead;

	private GameObject blackHole;


	
	void Start () {
		life = 25;
	}
	
	
	void Update () {

		hitable = BossController.hitable;
		if (life == 0) {
			Die ();
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (hitable && life > 0) {
			if (other.gameObject.CompareTag ("Bullet")) {
				life--;
				SetLife ();
			}
		}

		if (!hitable && life <25) {
			if (other.gameObject.CompareTag ("Bullet")) {
				life++;
				SetLife ();
			}

		}
	}

	void SetLife(){

		lifeBoss.text = life.ToString () + "/25";

	}

	void Die(){

		animBoss.SetTrigger ("die");
		Collider2D colEnemy;
		Collider2D colEnemy2;
		colEnemy = GetComponent<CircleCollider2D>();
		colEnemy.enabled = false;
		colEnemy2 = GetComponent<CapsuleCollider2D>();
		colEnemy2.enabled = false;
		wonText.SetActive (true);
		countDead.text = "You died " + GlobalVariables.dieCount + " times";
		GlobalVariables.bossActive = false;
		blackHole = GameObject.FindGameObjectWithTag ("BlackHole");
		Destroy (blackHole);


		}


}

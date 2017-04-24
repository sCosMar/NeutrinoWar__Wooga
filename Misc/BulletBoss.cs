using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour {

//Controls when the boss' bullet has to be destroy

	void Start () {

		Destroy (gameObject, 5);
		
	}
	
	void OnTriggerEnter2D (Collider2D other){

		if (!other.gameObject.CompareTag ("BlackHole")) {
			Destroy (gameObject);
		}
	}
}

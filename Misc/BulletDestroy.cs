using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {

//Controls when the bullet (player's or enemy's) has to be destroy
	void Start () {

		Destroy (gameObject, 5);
		
	}
	
	void OnTriggerEnter2D (Collider2D other){

		if (!other.gameObject.CompareTag ("Life")) {
			Destroy (gameObject);
		}
	}
}

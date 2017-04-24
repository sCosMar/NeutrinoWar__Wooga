using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCount : MonoBehaviour {
	
	//Destroys the life pick-up when the player picks it up
	
	void OnTriggerEnter2D (Collider2D other){

		if(other.gameObject.CompareTag("Player")){

			if(GlobalVariables.life<3)

			Destroy(gameObject);

		}
	}
}

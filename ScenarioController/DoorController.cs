using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

//Checks if the player has the whole key before he can go to the boss room

	public GameObject door;
	public GameObject noKey;
	public GameObject camera;

	
	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.CompareTag ("Player")) {

			if (GlobalVariables.firstKey && GlobalVariables.secondKey) {
				Destroy (door);
				camera.transform.parent = null;
			}

			if (!GlobalVariables.firstKey || !GlobalVariables.secondKey) {
				noKey.SetActive (true);
			}

		}
	}

	void OnTriggerExit2D(Collider2D other){

		if (other.gameObject.CompareTag ("Player")) {

			if (!GlobalVariables.firstKey || !GlobalVariables.secondKey) {
				noKey.SetActive (false);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour {

//Starts the combar against the boss

	public GameObject camera;
	public GameObject lifeBoss;

	private Camera cam;

	private bool cameraFree=false;

	void Start(){
		cam = camera.GetComponent<Camera> ();
		GlobalVariables.bossActive = false;
	}

	void FixedUpdate(){

		if (cameraFree) {
			if (cam.orthographicSize < 1) {
				cam.orthographicSize += 0.01f;
			}

			if (camera.transform.position.x < 0.31f) {
				camera.transform.position += new Vector3 (0.01f, 0, 0); 
			}

			if (camera.transform.position.y < 0.40f) {
				camera.transform.position += new Vector3 (0f, 0.01f, 0); 
			}

		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			camera.transform.parent = null;
			cameraFree = true;
			StartCoroutine ("StartBoss");

		}

	}

	IEnumerator StartBoss(){
		yield return new WaitForSeconds (2);
		GlobalVariables.bossActive = true;
		lifeBoss.SetActive (true);
		Destroy (gameObject);
	}


}

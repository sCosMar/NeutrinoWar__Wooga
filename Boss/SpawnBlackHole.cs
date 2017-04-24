using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//During the boss, black holes will apear randomly in 4 spawn points. This scripts controls the spawn.

public class SpawnBlackHole : MonoBehaviour {

	private float n;
	public GameObject blackHole;
	public Transform left;
	public Transform right;
	public Transform centerLeft;
	public Transform centerRight;
	private GameObject newBlackHole;


	// Use this for initialization
	void Start () {

		n = Random.Range (0f, 1f);
		Spawn();
			
	}

	
	void Spawn(){

		if (GlobalVariables.bossActive) {
			if (n >= 0 && n < 0.25f) {
				newBlackHole = (GameObject)Instantiate (blackHole, left.position, Quaternion.identity);
				StartCoroutine (TimeSpawn());
			} else if (n >= 0.25f && n < 0.5f) {
				newBlackHole = (GameObject)Instantiate (blackHole, centerLeft.position, Quaternion.identity);
				StartCoroutine (TimeSpawn());
			} else if (n >= 0.5f && n < 0.75f) {
				newBlackHole = (GameObject)Instantiate (blackHole, centerRight.position, Quaternion.identity);
				StartCoroutine (TimeSpawn());
			} else if (n >= 0.75f && n <= 1f) {
				newBlackHole = (GameObject)Instantiate (blackHole, right.position, Quaternion.identity);
				StartCoroutine (TimeSpawn());
			}
		} else if (!GlobalVariables.bossActive){
			
			StartCoroutine (TimeSpawn());
		}


	}

	IEnumerator TimeSpawn(){

		yield return new WaitForSeconds (2.2f);
		n = Random.Range (0f, 1f);
		Spawn ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Saves the player variables (life and keys)

public class PlayerVariables : MonoBehaviour {

	PlayerController player;
	public GameObject keyOne;
	public GameObject keyTwo;

	//UI

	public GameObject noKey;
	public GameObject oneKey;
	public GameObject twoKey;

	public GameObject noLife;
	public GameObject oneLife;
	public GameObject twoLife;
	public GameObject threeLife;


	public AudioSource key;



	void Start () {

		player = GameObject.FindObjectOfType<PlayerController> ();

		oneKey.SetActive(false);
		twoKey.SetActive(false);

		noLife.SetActive (false);
		oneLife.SetActive (false);
		twoLife.SetActive (false);

		GlobalVariables.firstKey = false;
		GlobalVariables.secondKey = false;
		GlobalVariables.life = 3;

	}

	void Update(){

		switch (GlobalVariables.life) {

		case 0:
			noLife.SetActive (true);
			oneLife.SetActive (false);
			twoLife.SetActive (false);
			threeLife.SetActive (false);
			player.Die ();
			StartCoroutine ("Diedie");
			break;

		case 1:
			noLife.SetActive (false);
			oneLife.SetActive (true);
			twoLife.SetActive (false);
			threeLife.SetActive (false);
			break;

		case 2: 
			noLife.SetActive (false);
			oneLife.SetActive (false);
			twoLife.SetActive (true);
			threeLife.SetActive (false);
			break;

		case 3:
			noLife.SetActive (false);
			oneLife.SetActive (false);
			twoLife.SetActive (false);
			threeLife.SetActive (true);
			break;

		default: 
			noLife.SetActive (false);
			oneLife.SetActive (false);
			twoLife.SetActive (false);
			threeLife.SetActive (false);
			break;


		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Key1")) {

			GlobalVariables.firstKey = true;
			oneKey.SetActive (true);
			noKey.SetActive (false);
			key.Play ();
			Destroy (keyOne);

		}

		if (other.gameObject.CompareTag ("Key2")) {

			GlobalVariables.secondKey = true;
			twoKey.SetActive (true);
			noKey.SetActive(false);
			key.Play ();
			Destroy (keyTwo);

		}

	}

	IEnumerator Diedie(){

		yield return new WaitForSeconds (2);
		GlobalVariables.dieCount++;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
	

}

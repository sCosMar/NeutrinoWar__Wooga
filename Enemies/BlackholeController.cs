using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Black holes will fall during the boss combat. When they touch the ground they will disappear. Also, they can't be at the scene if the player is dead or the combat hasn't begun or it's over

public class BlackholeController : MonoBehaviour {

	private Rigidbody2D rb;

	void Start(){

		rb = GetComponent<Rigidbody2D> ();
	}

	void Update(){

		if (GlobalVariables.playerDead || !GlobalVariables.bossActive) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Ground")) {
			Destroy (gameObject);
		}
	}

	void FixedUpdate(){

		rb.transform.Translate(Vector3.down*0.019f);



	}
}

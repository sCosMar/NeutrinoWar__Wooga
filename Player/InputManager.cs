using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script links the input (either keyboard and xbox controller) with
//the player controller script

public class InputManager : MonoBehaviour {


	public float joystickDeadZone = 0.1f;
	public float joystickSensitivity = 2.0f;
	public float mouseSensitivity = 2.0f;

	PlayerController player;


	void Start () {

		player = GameObject.FindObjectOfType<PlayerController> ();
	}
	

	void Update () {

		Movement ();
		Jump ();
		Shoot ();
		
	}

	private void Movement(){

		float forward = Input.GetAxis ("Horizontal");

		if (Mathf.Abs (forward) < joystickDeadZone) {
			forward = 0;
		}

		float direction = forward;
		player.Movement (direction);

	}

	private void Jump(){

		bool jump = Input.GetKeyDown (KeyCode.Space);

		if (Input.GetKeyDown (KeyCode.JoystickButton0)) {
			jump = Input.GetKeyDown (KeyCode.JoystickButton0);
		}

		if (jump) {
			player.Jump();
		}

	}

	private void Shoot(){

		bool shoot = Input.GetKeyDown (KeyCode.X);


		if (Input.GetKeyDown(KeyCode.JoystickButton1)){
			shoot = Input.GetKeyDown (KeyCode.JoystickButton1);
		}

		if (shoot) {
			player.Shoot ();
		}
	}
}

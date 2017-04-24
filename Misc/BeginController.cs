using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginController : MonoBehaviour {

//Controls the images in the beginning of the level (story, mechanics and controls)

	public GameObject first;
	public GameObject second;

	private bool firstAct = false;
	private bool secondAct = false;



	void Update () {

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.JoystickButton0)) {
			if (!firstAct) {
				first.SetActive (true);
				firstAct = true;
			} else if (!secondAct) {
				second.SetActive (true);
				secondAct = true;
			}else if (firstAct && secondAct){
				SceneManager.LoadScene ("level0");
			}
		}
		
	}
}

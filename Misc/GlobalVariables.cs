using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {

//Saves some variables that are used in different scripts

	public static bool firstKey;
	public static bool secondKey;
	public static int life;
	public static bool bossActive;
	public static int dieCount;
	public static bool playerDead;

	void Awake(){

		dieCount = 0;
	}


}

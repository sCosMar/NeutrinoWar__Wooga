using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {

//A physic material has been used to avoid the player get stucked on the walls. This script avoids collision between the collider with that material and the ground's collider

	
	void Update () {

		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer ("Oil"), LayerMask.NameToLayer ("Ground"));
		
	}
}

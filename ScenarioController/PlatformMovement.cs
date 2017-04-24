using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

//Controls all the platforms in the level

	public enum HorizontalDirection { Left, Right }
	public enum VerticalDirection { Up, Down }

		
		public float horizontalSpeed = 0.3f;

		
		public HorizontalDirection wayH = HorizontalDirection.Right;

		
		public float verticalSpeed = 0.0f;

		
		public VerticalDirection wayV = VerticalDirection.Up;

		
		public float maxPingPong = 5.0f;

		
		private Transform platformTransform;
		private float walkedDistanceH = 0.0f;
		private float walkedDistanceV = 0.0f;
		private float referencePingPongHPosition;
		private float referencePingPongVPosition;

	

		void Start (){
			platformTransform = gameObject.transform;

			referencePingPongHPosition = platformTransform.position.x;

			referencePingPongVPosition = platformTransform.position.y;
		}
		

	void Update () {

		
		walkedDistanceH = Mathf.Abs(platformTransform.position.x - referencePingPongHPosition);

		
		walkedDistanceV = Mathf.Abs(platformTransform.position.y - referencePingPongVPosition);

		if (maxPingPong != -1 && walkedDistanceH >= maxPingPong)
		{
			
			if (wayH == HorizontalDirection.Left)
			{
				wayH = HorizontalDirection.Right;
			}
			else
			{
				wayH = HorizontalDirection.Left;
			}

			referencePingPongHPosition = platformTransform.position.x;
		}

		if (maxPingPong != -1 && walkedDistanceV >= maxPingPong)
		{
			
			if (wayV == VerticalDirection.Up)
			{
				wayV = VerticalDirection.Down;
			}
			else
			{
				wayV = VerticalDirection.Up;
			}

			referencePingPongVPosition = platformTransform.position.y;
		}

		
		if (wayH == HorizontalDirection.Left)
		{
			horizontalSpeed = -Mathf.Abs(horizontalSpeed);
		}
		else
		{
			horizontalSpeed = Mathf.Abs(horizontalSpeed);
		}

		
		if (wayV == VerticalDirection.Down)
		{
			verticalSpeed = -Mathf.Abs(verticalSpeed);
		}
		else
		{
			verticalSpeed = Mathf.Abs(verticalSpeed);
		}

		platformTransform.Translate(new Vector3(horizontalSpeed, verticalSpeed, 0) * Time.deltaTime);

		
	}



	void OnTriggerEnter2D(Collider2D other)
	{
		other.transform.parent = transform;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		other.transform.parent = null;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemies will go left and right until the player is close enough to them. Then, they will start shoot in one direction until the player goes away from range

public class EnemyController : MonoBehaviour {


	public enum StartDirection {Left, Right};
	private float speed = 0.8f;
	public StartDirection direction = StartDirection.Right;
	public float maxPingPong = 1f; 
	public Transform playerPos;


	private float referencePosition;
	private float walkedDistance = 0f;
	private SpriteRenderer enemySprite;
	private bool playerSeen;
	private bool die;

	public GameObject bullet;
	public SpriteRenderer bulletSprite;
	public Rigidbody2D rbBullet;
	public Transform bulletPos;
	private float bulletSpeed = 3f;
	private float timeLastBullet;


	public Animator animEnemy;

	public AudioSource shoot;


	void Start () {

		referencePosition = gameObject.transform.position.x;
		enemySprite = GetComponent<SpriteRenderer> ();
		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer ("Enemy"), LayerMask.NameToLayer ("Enemy"));
		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer ("Enemy"), LayerMask.NameToLayer ("Player"));
		playerSeen = false;
		timeLastBullet = 0;
		die = false;
	}
	

	void Update () {


		TargetPlayer ();

		if (!playerSeen && !die) {
			
			walkedDistance = Mathf.Abs (gameObject.transform.position.x - referencePosition);

			if (walkedDistance >= maxPingPong) {

				if (direction == StartDirection.Left) {

					direction = StartDirection.Right;
					enemySprite.flipX = true;
					bulletPos.localPosition = new Vector3 (0.21f, 0.09f);

				} else {

					direction = StartDirection.Left;
					enemySprite.flipX = false;
					bulletPos.localPosition = new Vector3 (-0.21f, 0.09f);
				}
				referencePosition = gameObject.transform.position.x;
		
			}

			if (direction == StartDirection.Left) {

				speed = -Mathf.Abs (speed);

			} else {

				speed = Mathf.Abs (speed);

			}

			gameObject.transform.Translate (new Vector3 (speed, 0, 0) * Time.deltaTime);

		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Bullet")) {

			animEnemy.SetTrigger ("die");
			die = true;
			StartCoroutine ("Die");
		}

	}

	void TargetPlayer(){

		float angle = Vector3.Angle (gameObject.transform.position, playerPos.position);
		float distance = gameObject.transform.position.x - playerPos.position.x;

		if (!die) {

			GameObject newbullet;

			if (Mathf.Abs (angle) < 1 && Mathf.Abs (distance) < 1) {

				playerSeen = true;

				if (Time.time - timeLastBullet > 1f) {

					animEnemy.SetTrigger ("attack");
					shoot.Play ();
					timeLastBullet = Time.time;

					if (distance > 0) {

						enemySprite.flipX = false;
						bulletPos.localPosition = new Vector3 (-0.21f, 0.09f);
						newbullet = (GameObject)Instantiate (bullet, bulletPos.position, Quaternion.identity);
						rbBullet = newbullet.GetComponent<Rigidbody2D> ();
						rbBullet.velocity = new Vector2 (-bulletSpeed, 0);

					} else if (distance < 0) {

						enemySprite.flipX = true;
						bulletPos.localPosition = new Vector3 (0.21f, 0.09f);
						newbullet = (GameObject)Instantiate (bullet, bulletPos.position, Quaternion.identity);
						rbBullet = newbullet.GetComponent<Rigidbody2D> ();
						rbBullet.velocity = new Vector2 (bulletSpeed, 0);

					}
				}

			} else if (Mathf.Abs (distance) > 1 && Mathf.Abs (angle) > 5) {

				playerSeen = false;

			}
		}




	}

	IEnumerator Die(){
		Collider2D colEnemy;
		colEnemy = GetComponent<CircleCollider2D>();
		colEnemy.enabled = false;
		yield return new WaitForSeconds (2);
		Destroy (gameObject);

	}



}



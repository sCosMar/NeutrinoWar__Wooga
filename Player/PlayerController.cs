using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// All functions and variables needed to control the player 

public class PlayerController : MonoBehaviour {

	//movement
	private float speed = 0.8f;
	private float jumpForce = 3.5f;
	private SpriteRenderer playerSprite;
	private bool grounded;



	public Animator animPlayer;
	private Rigidbody2D rb;



	//shooting
	public GameObject bullet;
	private float timeLastBullet;
	public SpriteRenderer bulletSprite;
	public Rigidbody2D rbBullet;
	public Transform bulletPos;
	private float bulletSpeed = 5f;

	

	
	//audios
	public AudioSource jump;
	public AudioSource shoot;
	public AudioSource life;
	public AudioSource bh;
	public AudioSource damage;


	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		playerSprite = GetComponent<SpriteRenderer> ();
		GlobalVariables.playerDead = false;
		timeLastBullet = 0;


	}

	void Update() {

		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Platform"), (GetComponent<Rigidbody2D>().velocity.y>0));

		if (rb.velocity.x == 0) {
			animPlayer.SetBool ("walk", false);
		} else if (Mathf.Abs(rb.velocity.x)>0.001f){
			animPlayer.SetBool ("walk", true);
		}

		if (!grounded) {
			animPlayer.SetBool ("jump", true);
		} else {
			animPlayer.SetBool ("jump", false);
		}

	}


	public void Movement (float direction){

		if (!GlobalVariables.playerDead) {
			rb.velocity = new Vector2 (direction * speed, rb.velocity.y);
		

			if (direction > 0) {
				playerSprite.flipX = false;

				bulletPos.localPosition = new Vector3 (0.22f, 0.024f);
			} else if (direction < 0) {
				playerSprite.flipX = true;
				bulletPos.localPosition = new Vector3 (-0.22f, 0.024f);
			}
		}

	}

	public void Jump (){

		if (!GlobalVariables.playerDead) {
			if (grounded) {
				jump.Play ();
				rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
			}
		}

	}

	public void Shoot (){

		if (!GlobalVariables.playerDead) {
			if (Time.time - timeLastBullet > 0.5f) {

				timeLastBullet = Time.time;
				GameObject newbullet;
				animPlayer.SetTrigger ("attack");
				shoot.Play ();

				if (playerSprite.flipX == false) {

					newbullet = (GameObject)Instantiate (bullet, bulletPos.position, Quaternion.identity);
					rbBullet = newbullet.GetComponent<Rigidbody2D> ();
					rbBullet.velocity = new Vector2 (bulletSpeed, 0);

				} else if (playerSprite.flipX == true) {

					newbullet = (GameObject)Instantiate (bullet, bulletPos.position, Quaternion.identity);
					rbBullet = newbullet.GetComponent<Rigidbody2D> ();
					rbBullet.velocity = new Vector2 (-bulletSpeed, 0);

				}

			}
		}

	}

	public void Die(){ //Called when the player has 0HP
		
		animPlayer.SetTrigger ("die");
		GlobalVariables.playerDead = true;

	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Ground") || other.gameObject.CompareTag ("Platform")) { //To control the jump

			grounded = true;

		}

		if (other.gameObject.CompareTag ("Enemy") || other.gameObject.CompareTag ("EnemyBullet") || other.gameObject.CompareTag ("Boss")) { //Controls when the player must lose 1HP
			if (GlobalVariables.life > 0) {
				GlobalVariables.life--;
				damage.Play ();

			}
		}

		if (other.gameObject.CompareTag ("Life")) { //+1HP when a life is picked up
			if (GlobalVariables.life < 3) {
				GlobalVariables.life++;
				life.Play ();
			}

		}

		if(other.gameObject.CompareTag("BlackHole")){ //Insta-die when the player touches a black hole

			animPlayer.SetTrigger ("diebh");
			bh.Play ();
			GlobalVariables.playerDead = true;
			StartCoroutine (DieBH ());

		}
	}

	void OnTriggerStay2D(Collider2D other){

		if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Platform")){

			grounded = true;

		}
			
	}

	void OnTriggerExit2D(Collider2D other){

		if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Platform")){

			grounded = false;

		}


	}

	
	IEnumerator DieBH(){ //Called when the player touches a black hole

		yield return new WaitForSeconds (2.5f);
		GlobalVariables.dieCount++;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}




	
}

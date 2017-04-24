using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controls the boss mechanics. Basically, when the combat begins, the boss life goes 1HP down when a player bullet hits him. The boss will shoot 5 times, after that he will change and will became "non-hitable" and
//if the boss is hit in this fase he will win 1HP, after 5 shots, he turns "hitable" again. This will repeat during the whole combat

public class BossController : MonoBehaviour {


	public GameObject bullet;
	public Rigidbody2D rbBullet;
	public Transform bulletPos;
	private float bulletSpeed = 2f;
	private float timeLastBullet;


	private int countBullet;

	public Animator animBoss;

	private bool shootFase;
	public static bool hitable;

	public AudioSource shoot;

	// Use this for initialization
	void Start () {

		shootFase = true;
		hitable = true;
		animBoss.SetBool ("hitable", true);
		countBullet = 0;
		timeLastBullet = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalVariables.bossActive) {
			if (shootFase) {
				Shoot ();
			} else if (!shootFase) {
				Change ();
			}
		}
		
	}

	void Shoot(){

		GameObject newbullet;

		if (countBullet < 5) {
			
			if (Time.time - timeLastBullet > 1f) {

				animBoss.SetTrigger ("attack");
				shoot.Play ();
				timeLastBullet = Time.time;
				newbullet = (GameObject)Instantiate (bullet, bulletPos.position, Quaternion.identity);
				rbBullet = newbullet.GetComponent<Rigidbody2D> ();
				rbBullet.velocity = new Vector2 (-bulletSpeed, 0);
				countBullet++;

			}
		} else {

			shootFase = false;
			countBullet = 0;
		}
	}

	void Change(){

		hitable = !hitable;
		animBoss.SetBool ("hitable", hitable);
		shootFase = true;

	}


}

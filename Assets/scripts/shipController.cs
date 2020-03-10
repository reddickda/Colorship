using UnityEngine;
using UnityEngine.UI;


#if UNITY_EDITOR_OSX
using UnityEditor;
#endif

using System.Collections;

public class shipController : MonoBehaviour {
	private SpriteRenderer spriteRenderer;
	public float moveSpeed;
	public Sprite[] shipChange;

	public float bulletTime;
	public bool canShoot = true;

	public int health = 5;

	bool isHit;
	public float timeHit = -1;

	public GameObject deadMenu;
	public bool death = false;

	public float startTime = .8f;
	
	public Ships ship = Ships.red;
	public Ships sprite = Ships.red;

	public GameObject healthBar;
	private HealthScript hbScript;

	public GameObject Bullet;
	public GameObject bluship;
	public GameObject redship;
	public GameObject ylwship;
	public Vector3 screen;
	public AudioSource au_shipdead;
	public AudioSource au_lasers;
	public AudioSource au_shiphit;

	public GameObject explode;

	float sinceDamaged;
	bool damagable = true;

	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		screen = new Vector3 (Screen.width, Screen.height);
		screen = Camera.main.ScreenToWorldPoint (screen);
		hbScript = healthBar.GetComponent<HealthScript>();
	}
	void changer(Ships change)
	{
		ship = change;
		if (change != sprite) {
			sprite=change;
			switch (change) {
			case Ships.red: 
				GetComponent <SpriteRenderer>().sprite= shipChange[0];
				break;
			case Ships.blue: 
				GetComponent <SpriteRenderer>().sprite= shipChange[1];
				break;
			case Ships.yellow: 
				GetComponent <SpriteRenderer>().sprite= shipChange[2];
				break;
			}
		}
	}
	// Update is called once per frame
	void Update () {
				if (PauseManager.pause) {
						rigidbody2D.velocity = Vector2.zero;
						return;
				}
				if (isHit == true && Time.time - timeHit > 1) {
						damage ();
						timeHit = Time.time;
				}
				if (!damagable) {
						float elapsed = Time.time - sinceDamaged;
						if (elapsed > 1.0f) {
								damagable = true;
						} else if (elapsed > .2 && elapsed < .3) {
								spriteRenderer.enabled = false;
						} else if (elapsed > .5 && elapsed < .6) {
								spriteRenderer.enabled = false;
						} else if (elapsed > .85 && elapsed < .95) {
								spriteRenderer.enabled = false;
						} else {
								spriteRenderer.enabled = true;
						}
				}

				//Moves the player
				rigidbody2D.velocity = new Vector2 (0, 0);
				if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
						rigidbody2D.velocity = new Vector2 (-moveSpeed, rigidbody2D.velocity.y);
				} else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
						rigidbody2D.velocity = new Vector2 (moveSpeed, rigidbody2D.velocity.y);
				}
				if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
						rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, moveSpeed);
						if (ship == Ships.yellow) {
								rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, moveSpeed + 2);
						}
				} else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
						rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, -moveSpeed);
				}

				//Checks bounds
				Vector3 pos = transform.position;
				if (pos.x < -screen.x + renderer.bounds.size.x / 2.0f) {
						pos.x = -screen.x + ((renderer.bounds.size.x) / 2.0f);
				} else if (pos.x > screen.x - renderer.bounds.size.x / 2.0f) {
						pos.x = screen.x - ((renderer.bounds.size.x) / 2.0f);
				}
				if (pos.y < -screen.y + renderer.bounds.size.y / 1.2) {
						pos.y = -screen.y + ((renderer.bounds.size.y / 1.2f));
				} else if (pos.y > screen.y - renderer.bounds.size.y / 2.0f) {
						pos.y = screen.y - ((renderer.bounds.size.y) / 2.0f);
				}
				transform.position = pos;

				if (Time.time - bulletTime > .25f) {
					canShoot = true;
				}

		//Shoots
		if (Input.GetKeyDown (KeyCode.Space)) {



			if(canShoot){
			GameObject bullet = (GameObject)Instantiate (Bullet, transform.position-new Vector3(0,-.7f,-2), Quaternion.identity);
			bullet.GetComponent<bulletController>().bulletColor = ship;
			au_lasers.Play();
				bulletTime = Time.time;
				canShoot = false;
			}
		}

		//Switches Players
		if(Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.E)){
			int s= (int)ship;
			s++;
			if(s>2)	s=0;
			changer ((Ships)s);
		} else if (Input.GetKeyDown(KeyCode.Q)) {
			int s= (int)ship;
			s--;
			if(s<0)	s=2;
			changer ((Ships)s);
		}


	}

	void OnTriggerEnter2D(Collider2D other){
		
		if ((other.tag == "deadly" && !other.gameObject.name.Contains ("bullet")) || other.tag == "deadlyenemy" || other.tag == "deadlyenemybullet" || other.tag == "invincibleEnemy") {
						Debug.Log ("Dead!");
						damage ();
						if (other.tag == "deadlyEnemyBullet") {
								Destroy (other.gameObject);
						}
				}
		}
	void OnTriggerStay2D(Collider2D other){
		if ( (other.tag == "hurtredblue" && ship != Ships.yellow) || 
		    (other.tag == "hurtblueyellow" && ship != Ships.red) ||
		    (other.tag == "hurtredyellow" && ship != Ships.blue)) {
			if(!isHit){
				timeHit = Time.time;
				damage ();
			}
			isHit = true;
		}
		else{
			isHit = false;
		}
		}
	Collider2D justLeft;
	void OnTriggerExit2D(Collider2D other){
		if (other != justLeft && ((other.tag == "hurtredblue" && ship != Ships.yellow) || (other.tag == "hurtblueyellow" && ship != Ships.red) || 
		    (other.tag == "hurtredyellow" && ship != Ships.blue))) {
			justLeft = other;
			isHit = false;
				}
		}

	

	void damage(){
		if (!damagable) {
						return;
				}
		sinceDamaged = Time.time;
		damagable = false;
		health--;
		if (hbScript !=null)
		hbScript.setHealth (health);
		au_shiphit.Play();
		//health BAR
		if(health == 0)
			Dies ();
			
			
		}
	
	void Dies(){
		if (explode != null)
		Instantiate (explode, transform.position, Quaternion.identity);
		au_shipdead.Play ();
		Destroy(this.gameObject, 0.0f);
		gameObject.tag = "deadly";
		death = !death;
		deadMenu.GetComponent<Canvas> ().enabled = death;
		GameObject.Find ("NextButton").SetActive (false);
	
		PauseManager.pause = true;
		PauseManager.death = true;
		
	}


	//NO ocde Belw
	#if UNITY_EDITOR_OSX
	[MenuItem("Edit/Reset PlayerPrefs")]
	public static void DeletePlayerPrefs(){
		PlayerPrefs.DeleteAll ();
		}
#endif
}
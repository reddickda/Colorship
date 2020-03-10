using UnityEngine;
using System.Collections;

public class enemyShipController : MonoBehaviour {
	public float Flyspeed;
	public bool isFinal;
	public bool isTriggerSharpShip;
	public bool sharpyGo = false;
	public int health = 1;
	public float time = 0;
	public float blinks = .5f;
	
	public GameObject exploder;
	public GameObject projectile;
	//private int collisionDamage = 5;
	//private int enemyHealth=10;
	// Use this for initialization
	public virtual void Start () {
		InvokeRepeating ("Shoot", 2.0f, 1.5f);
		health = 1;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if (PauseManager.pause) {
			rigidbody2D.velocity = Vector2.zero;
			return;
		}
		rigidbody2D.velocity = new Vector2 (0, Flyspeed);


	} 

	protected virtual void Shoot () {
		if (PauseManager.pause) {

			return;
		}
		Instantiate (projectile, transform.position, Quaternion.identity);


		}
	//public enemyShipController(float FlyspeedIn, int enemyHealthIn) {
	
		//Flyspeed = FlyspeedIn;
		//enemyHealth = enemyHealthIn;

	//}

	//enemy ship constructor

	


	//public enemyShipController(int health, int damage) {
		//enemyHealth = health;
		//collisionDamage = damage;
	//}

	//collision damage getter
	//public int getCollisionDamage() {
		//return collisionDamage;
	//}
	
	public virtual void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "deadly" && other.gameObject.tag != "deadlyenemy"){
			//Destroy(gameObject.name.Contains("bullet"));
			//Debug.Log("Dead!");
			//Application.LoadLevel(0);
			//exploder.Play();
			health--;
			blink ();
			if(health==0){
			Dies ();
			}
		}
		
	}
	

	
	
	public virtual void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "deadly" && other.gameObject.tag != "deadlyenemy") {
			//Debug.Log ("Dead!");
			//Application.LoadLevel (0);
			health--;
			blink ();
			if(health == 0 || other.gameObject.name == "player"){
			//exploder.Play();
			Dies ();
			}
		}
		
		
	}

	public void Dies(){

		Destroy (this.gameObject, 0.0f);
		gameObject.tag = "deadly";
		if (exploder != null) {
						Instantiate (exploder, transform.position, Quaternion.identity);
				}
		if (isFinal) {
						BossSpawner.getInstance ().spawn ();
				}

		
	}
	public void blink(){
		time = 0;
	
	}
}

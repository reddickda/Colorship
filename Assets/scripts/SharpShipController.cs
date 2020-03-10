using UnityEngine;
using System.Collections;

public class SharpShipController : enemyShipController {
	public float sideSpeed;
	public float farLeft;
	private float time;

	public float howLongTilSpawn;
	public GameObject projectile1;



	bool doneGoingLeft = false;
	// Use this for initialization
	public override void Start () {

		InvokeRepeating ("Shoot", 2.0f, .4f);
		time = Time.time;
		//base.Start ();
	}
	protected override void Shoot(){
		if (PauseManager.pause || (Time.time-time) < howLongTilSpawn) {
			return;
		}
		Instantiate (projectile1, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	public override void Update () {
		if (PauseManager.pause) {
			time += Time.deltaTime;
			return;
		}
		if ((Time.time - time) < howLongTilSpawn) {
			return;
		}
		//base.Update ();
	

        if ((Time.time - time) > howLongTilSpawn) {
				
				if (doneGoingLeft == false) {
						rigidbody2D.velocity = new Vector2 (sideSpeed, 0);
				}
				if (transform.position.x <= farLeft) {
						doneGoingLeft = true;
						rigidbody2D.velocity = new Vector2 (-sideSpeed, 0);
				}
		}

		if (transform.position.x > 15)
						Destroy (this.gameObject);
	}

	public override void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "deadly" && other.gameObject.tag != "deadlyenemy"  && other.gameObject.name != "player"){
			//Destroy(gameObject.name.Contains("bullet"));
			//Debug.Log("Dead!");
			//Application.LoadLevel(0);
			//exploder.Play();
			Destroy(other.gameObject);
			health--;
			blink ();

		}
		
	}
	
	
	
	
	public override void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "deadly" && other.gameObject.tag != "deadlyenemy" && other.gameObject.name != "player") {
			//Debug.Log ("Dead!");
			//Application.LoadLevel (0);
		
			Destroy(other.gameObject);
			health--;
			blink ();

		}
		
		
	}
}



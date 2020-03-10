using UnityEngine;
using System.Collections;

public class ZigZagScript : MonoBehaviour {

	public float Flyspeed;
	public float sideSpeed;
	public GameObject projectile;
	public bool isFinal;

	public GameObject exploder;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("Shoot", 2.0f, .8f);

	}
	
	// Update is called once per frame
	void Update () {

		if (PauseManager.pause) {
			rigidbody2D.velocity = Vector2.zero;
			return;
		}
		if (transform.position.x <= -4.0f) {
			sideSpeed = 4f;
				}
		if (transform.position.x >= 4.0f) {
			sideSpeed = -4f;
		}
		rigidbody2D.velocity = new Vector2 (sideSpeed, Flyspeed);
	}

	protected virtual void Shoot () {
		if (PauseManager.pause) {
			
			return;
		}
		Instantiate (projectile, transform.position, Quaternion.identity);
		
		
	}
	public virtual void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "deadly" && other.gameObject.tag != "deadlyenemy"){
			//Destroy(gameObject.name.Contains("bullet"));
			//Debug.Log("Dead!");
			//Application.LoadLevel(0);
			//exploder.Play();
			Dies ();
		}
		
	}
	
	
	
	
	public virtual void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "deadly" && other.gameObject.tag != "deadlyenemy") {
			//Debug.Log ("Dead!");
			//Application.LoadLevel (0);

			Dies ();
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
}

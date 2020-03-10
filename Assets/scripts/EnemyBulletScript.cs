using UnityEngine;
using System.Collections;

public class EnemyBulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public float speed;
	// Update is called once per frame
	void Update () {
		if (PauseManager.pause) {
			rigidbody2D.velocity = Vector2.zero;
			return;
		}
		rigidbody2D.velocity = new Vector2 (0, speed);
		if ((transform.position.y > 20)) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "deadly" && other.gameObject.name.Contains("player")){
			Destroy(this.gameObject);
			//Debug.Log("Dead!");
			//Application.LoadLevel(0);
			//Dies ();
		}

		
	}
	
	
	
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "deadly" && other.gameObject.name.Contains("player")) {
			//Debug.Log ("Dead!");
			//Application.LoadLevel (0);
			//Dies();
		}
		
		
	}
	void Dies(){
		Destroy (this.gameObject, 0.0f);
		gameObject.tag = "deadly";
		
	}

}

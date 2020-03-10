using UnityEngine;
using System.Collections;

public class bulletController : MonoBehaviour {
	private int damage=5;
	public Ships bulletColor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame


		public float speed;
		// Update is called once per frame
		void Update () {

		rigidbody2D.velocity = new Vector2 (0, speed);
		if ((transform.position.y > 20)) {
			Destroy(gameObject);
			}
		}
	void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "deadly" && !other.gameObject.name.Contains("player") || other.tag == "deadlyenemy" && !other.gameObject.name.Contains("player")){
			//Debug.Log("Dead!");
			//Application.LoadLevel(0);
			Dies ();
		}
		if (this.gameObject.tag == "deadly" && other.gameObject.tag == "deadlyenemy") {
			Dies ();
		}
		
	}




	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "deadly" && !other.gameObject.name.Contains("player")|| other.gameObject.tag == "deadlyenemy" && !other.gameObject.name.Contains("player")) {
			//Debug.Log ("Dead!");
			//Application.LoadLevel (0);
			Dies();
		}
		if (this.gameObject.tag == "deadly" && other.gameObject.tag == "deadlyenemy") {
			Dies ();
				}
		
	}
	void Dies(){
		Destroy (this.gameObject, 0.0f);

		gameObject.tag = "deadly";
		
	}
	
	//bullet construct
	//public bulletController(int damageIn) {

		//damage = damageIn;

	//}

	//getter for damage
	//public int getDamage() {
		//return damage;
	//}
}
using UnityEngine;
using System.Collections;

public class barrierScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "deadlyenemybullet"||other.gameObject.tag == "deadly") {
						Dies (other.gameObject);
						
				}
		}


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "deadlyenemybullet"||other.gameObject.tag == "deadly") {
			Dies (other.gameObject);
				}

		}

	void Dies(GameObject other){
		
		Destroy (other.gameObject, 0.0f);

	}	
}

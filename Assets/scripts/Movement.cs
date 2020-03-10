using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PauseManager.pause) {
			return;
		}
		rigidbody2D.velocity = new Vector2 (0, speed);
	}

		


	void Dies(){

	Destroy (this.gameObject, 0.0f);
	gameObject.tag = "deadly";
		
		}	


	}
	



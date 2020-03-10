using UnityEngine;
using System.Collections;

public class auramOvement : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PauseManager.pause) {
			rigidbody2D.velocity = Vector2.zero;
			return;
		}
		rigidbody2D.velocity = new Vector2 (0, speed);
	}
}

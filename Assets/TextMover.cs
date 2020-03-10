using UnityEngine;
using System.Collections;

public class TextMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2 (0, -2.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (PauseManager.pause) {
			rigidbody2D.velocity = Vector2.zero;
			return;
		}
		rigidbody2D.velocity = new Vector2 (0, -2.5f);
	}
}

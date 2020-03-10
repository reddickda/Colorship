using UnityEngine;
using System.Collections;

public class BGmovement : MonoBehaviour {
	public float ReallyLongPeni;
	public GameObject Background;
	private float height;
	public Vector3 screen;
	// Use this for initialization
	void Start () {
		Vector3 screen = new Vector3 (Screen.width, Screen.height);
		screen = Camera.main.ScreenToWorldPoint (screen);
		height = screen.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (PauseManager.pause) {
			rigidbody2D.velocity = Vector2.zero;
			return;
		}

		rigidbody2D.velocity = new Vector2 (0, ReallyLongPeni);

		//if (transform.position.y-renderer.bounds.size.y/2.0f<-height) {
			//transform.position.y = height+renderer.bounds.size.y/2.0f;
		Vector3 pos = transform.position;
		if (pos.y < -15.5f) { //13.5
			transform.position = new Vector3(transform.position.x, 27.9f, transform.position.z);
			pos.y = 25.9f; //27.9
		
		}
	}
}

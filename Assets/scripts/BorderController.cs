using UnityEngine;
using System.Collections;

public class BorderController : MonoBehaviour {
	Vector3 screen;
	public bool isLeft;
	// Use this for initialization
	void Start () {
		screen = new Vector3 (Screen.width, Screen.height);
		screen = Camera.main.ScreenToWorldPoint (screen);
		if (isLeft) {
						transform.position = new Vector3 (-screen.x, 0, 0);
				} else {
					transform.position = new Vector3 (screen.x,0,0);
				}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

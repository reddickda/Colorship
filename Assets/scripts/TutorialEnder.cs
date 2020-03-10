using UnityEngine;
using System.Collections;

public class TutorialEnder : MonoBehaviour {
	public GameObject bar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(  other.gameObject == bar || other.tag == "killAll" ) {
			Application.LoadLevel ("MainMenu");
		}
	}
}

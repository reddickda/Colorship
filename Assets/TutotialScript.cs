using UnityEngine;
using System.Collections;

public class TutotialScript : MonoBehaviour {
	public GameObject player;
	public bool aura;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay2D(Collider2D other){

			if(  other.tag == "killAll" && this.tag != "hurtredyellow") {
				Application.LoadLevel ("MainMenu");
			}
		

			if( aura && other.name == "player" && (player.GetComponent<shipController>().ship != Ships.blue)) {
			Application.LoadLevel ("tutorial");
			}
	}
	void OnTriggerEnter2D(Collider2D other){
		
		if(  !aura && other.tag == "killAll" && this.tag != "hurtredyellow") {
			Application.LoadLevel ("MainMenu");
		}
		
		
		if( aura && other.name == "player" && (player.GetComponent<shipController>().ship != Ships.blue)) {
			Application.LoadLevel ("tutorial");
		}
	}
}
		
		


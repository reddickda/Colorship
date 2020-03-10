using UnityEngine;
using System.Collections;

public class SharpShipBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		
		if(other.gameObject.name.Contains("player")){
			Destroy(this.gameObject);
			//Debug.Log("Dead!");
			//Application.LoadLevel(0);
			//Dies ();
		}
		
		
	}
}

using UnityEngine;
using System.Collections;

public class pointOfNoReturn : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other){

			Dies (other.gameObject);
			

	}
	
	
	void OnTriggerEnter2D(Collider2D other){

			Dies (other.gameObject);

		
	}
	
	void Dies(GameObject other){
		enemyShipController final = other.GetComponent<enemyShipController> ();
		// add this for every future added ship
		if (final == null) {
			final = other.GetComponent<TuskshipController>();
				}
		if (final != null) {
			final.Dies();
		
				}
		else
		Destroy (other.gameObject, 0.0f);
		
	}	
}

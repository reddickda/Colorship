using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	public Sprite[] healthBar; 
	private SpriteRenderer render;

	void Start(){
		render = GetComponent<SpriteRenderer> ();
	}

	public void setHealth(int health){

		render.sprite = healthBar [health];



	}


}

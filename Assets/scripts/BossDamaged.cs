using UnityEngine;
using System.Collections;

public class BossDamaged : MonoBehaviour {
	public Ships color;
	public GameObject bossBullet;
	public float bulletTime;
	public int health;
	private float time;
	public Vector3 offset;
	public bool damagable = true;
	public GameObject exploder;
	private SpriteRenderer spriteRenderer;
	float timeAtHit;
	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (PauseManager.pause) {
			time += Time.deltaTime;
			return;
		}
		if (Time.time - timeAtHit < 1.0f) {
			float elapsed = Time.time - timeAtHit;
		
			 if (elapsed > .1 && elapsed < .2) {
				spriteRenderer.enabled = false;
			} else if (elapsed > .4 && elapsed < .5) {
				spriteRenderer.enabled = false;
			} else if (elapsed > .7 && elapsed < .8) {
				spriteRenderer.enabled = false;
			} else {
				spriteRenderer.enabled = true;
			}
				}
		if (Time.time - time > bulletTime) {

			Instantiate (bossBullet, transform.position + offset, Quaternion.identity);
			time = Time.time;
			}
				
	}

	void OnTriggerEnter2D(Collider2D other){
		if (damagable) {
			if (other.gameObject.name.Contains ("bullet")) {
				Ships ships = other.gameObject.GetComponent<bulletController>().bulletColor;
				if (ships == color) {
					timeAtHit = Time.time;
					health--;
				}
				if(health == 0){
					Destroy(this.gameObject);
					if (exploder != null) {
						Instantiate (exploder, transform.position, Quaternion.identity);
					}
				}
				Destroy(other.gameObject);
			}	
		}
	}

}

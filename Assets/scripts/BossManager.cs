using UnityEngine;
using System.Collections;

public class BossManager : MonoBehaviour {
	public Ships color;
	public GameObject bossBullet;
	public float bulletTime;
	public int health;
	private float time;
	public Vector3 offset;
	public GameObject exploder;
	public bool damagable = true;
	public float top;
	public float speed;
	public AudioSource au_bossSong;
	public float leftBound;
	public float rightBound;
	public GameObject[] auras = new GameObject[3];
	public GameObject blueA;
	public GameObject redA;
	public GameObject yelA;
	bool directionLeft = true;
	bool doneOnce = false;
	 int whichAura = 1;


	 bool initialPush = false;
	bool headDam = false;

	bool stopped = false;

	public GameObject[] parts;
	GameObject head;


	// Use this for initialization
	void Start () {
		auras[0] = blueA;
		auras [1] = redA;
		auras [2] = yelA;
		head = parts[0];
		au_bossSong.Play ();
		rigidbody2D.velocity = new Vector2 (0, -speed);
	}
	
	// Update is called once per frame
	void Update () {
		if (PauseManager.pause) {
			rigidbody2D.velocity = Vector2.zero;
			CancelInvoke("shootAuras");
			doneOnce = false;
			return;
		}

		if (Time.time - time > bulletTime) {
			Instantiate (bossBullet, transform.position + offset, Quaternion.identity);
			time = Time.time;
		}
		if (parts [0] != null) {
			headDam = (parts[1] == null && parts[2] == null);
			if (!parts[0].GetComponent<BossDamaged>().damagable) 
				parts[0].GetComponent<BossDamaged>().damagable = headDam;

			if(headDam){

				 if(directionLeft){
					rigidbody2D.velocity = new Vector2 (-3, 0);
				}
				else if(!directionLeft){
					rigidbody2D.velocity = new Vector2 (3, 0);
				}
			}
			if(headDam && !doneOnce){
				doneOnce = true;
				if(Application.loadedLevelName != "Colorship")
					InvokeRepeating( "shootAuras", 1.0f, 2.0f);
			}


			if(headDam){
				if(!(initialPush)){
					initialPush = true;
					directionLeft = true;
					rigidbody2D.velocity = new Vector2 (-3, 0);
				}

				else if ( transform.position.x <= leftBound){
					directionLeft = false;
					rigidbody2D.velocity = new Vector2 (3, 0);
				}
				else if(transform.position.x >= rightBound){
					directionLeft = true;
						rigidbody2D.velocity = new Vector2 (-3, 0);
					}
				}
			}
				
		bool alive = false;

		for (int i = 0; i < parts.Length; i++) {
			if(parts[i] != null){
				alive = true;
				break;
			}
		}
		if (!alive) {
			BossSpawner.getInstance().won ();
			Destroy(this.gameObject);
			return;
		}
		if (transform.position.y <= top) {
			if (!stopped){
				rigidbody2D.velocity = new Vector2 (0,0);
				stopped = true;
			}
		}
	}
	public void shootAuras(){

		 whichAura = Random.Range (0, 3);

		Instantiate (auras [whichAura], transform.position, Quaternion.identity);

		}
	void OnTriggerEnter2D(Collider2D other){
		if (damagable) {
			if(this == parts[0] && headDam){
			if (other.gameObject.name.Contains ("bullet")) {
				Ships ships = other.gameObject.GetComponent<bulletController>().bulletColor;
				if (ships == color) {
					health--;
				}
				if(health == 0){
						if (exploder != null) {
							Instantiate (exploder, transform.position, Quaternion.identity);
						}
					Destroy(this.gameObject);
				}
				Destroy(other.gameObject);
				}
			}
				else if (this != parts[0]){
					if (other.gameObject.name.Contains ("bullet")) {
						Ships ships = other.gameObject.GetComponent<bulletController>().bulletColor;
						if (ships == color) {
							health--;
						}
						if(health == 0){
						if (exploder != null) {
							Instantiate (exploder, transform.position, Quaternion.identity);
						}
							Destroy(this.gameObject);
						}
						Destroy(other.gameObject);

				}
			}	
		}
	}
}

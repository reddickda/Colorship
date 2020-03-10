using UnityEngine;
using System.Collections;

public class TuskshipController : enemyShipController {
	public GameObject _player;


	public string ObjectName = "tuskship";
	// Use this for initialization
	public override void Start () {

		base.Start ();
		health = 2;
		_player = GameObject.Find ("Player");
		// InvokeRepeating ("Shoot", 2.0f, 1.5f);
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update ();
		if (PauseManager.pause) {
			rigidbody2D.velocity = Vector2.zero;
			return;
		}



		//rigidbody2D.velocity = new Vector2 (0, Flyspeed);

	if (_player != null) {
			Vector3 direction = _player.transform.position - transform.position;

			direction.Normalize();
			direction *= Flyspeed;

			if (direction.x < 0)
				transform.eulerAngles = new Vector3 (0, 180, 0);
			else if (direction.x > 0)
				transform.eulerAngles = new Vector3 (0, 0, 0);
				}
	}



}

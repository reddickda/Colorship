using UnityEngine;
using System.Collections;

public class createObject : MonoBehaviour {
	public GameObject ObjectToCreate;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			Vector3 mouse= Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouse.z=0;
			GameObject obj = Instantiate (ObjectToCreate) as GameObject;
			obj.transform.position=mouse;
		}
	}
}

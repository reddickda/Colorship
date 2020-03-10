using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {
	public GameObject pauseMenu;
	public static bool pause, death;


	void Start(){

		pause = false;
		death = false;
		}

	private void Update(){
		if (Input.GetKeyDown (KeyCode.P) && !death) {
			pause = !pause;
			pauseMenu.GetComponent <Canvas>().enabled=pause;
				}
		}

}

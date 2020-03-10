using UnityEngine;
using System.Collections;

public class buttonEvents : MonoBehaviour {

	public void onMainMenuClick(){
		Application.LoadLevel ("MainMenu");
		}

public void onPlayClick(){
		Application.LoadLevel ("Colorship");
		PauseManager.death = false;
		PauseManager.pause = false;

}
	public void onTutorialClick(){
		Application.LoadLevel ("tutorial");
		}
	public void onLevel2Click(){
		Application.LoadLevel ("ColorshipLevel2");
		}
	public void onLevel3Click(){
		Application.LoadLevel ("ColorshipLevel3");
	}
	public void onRetryClick(){
		Application.LoadLevel (Application.loadedLevelName);
	}
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossSpawner : MonoBehaviour {
	private static BossSpawner bossSpawner;
	public AudioClip song;
	public GameObject boss;
	public GameObject deadMenu;
	public GameObject[] auras = new GameObject[3];
	public GameObject blueA;
	public GameObject redA;
	public GameObject yelA;

	bool isSpawned = false;
	int whichAura = 1;
	// Use this for initialization
	void Start () {
		bossSpawner = this;
 		
	}
	void Update(){

		whichAura = Random.Range (0, 2);
		}

	public static BossSpawner getInstance(){

		return bossSpawner;
	}
	public void spawn(){
		if (isSpawned == false) {
			Instantiate (boss, new Vector3 (.2f, 16.1f, 3f), Quaternion.identity);
			isSpawned = true;
			AudioManager.Play (song);
				}

		}
	public void won(){
		deadMenu.GetComponent<Canvas> ().enabled = true;
		PauseManager.pause = true;
		string status = "You've damaged their forces.\nGo to the next level to keep fighting!";
		if (Application.loadedLevelName == "ColorshipLevel3") {
			status = "Congratulations! Because of you,\nyour planet is free to gather resources.";
			GameObject.Find("NextButton").SetActive(false);
				}


		GameObject.Find ("Status").GetComponent<Text> ().text = status;
		GameObject.Find ("RetryButton").SetActive (false);
	}
}

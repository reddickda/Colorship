using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	static AudioManager audioManager;
	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioManager = this;
	}

	public void play(AudioClip song){
		audioSource.Stop ();
		audioSource.clip = song;
		audioSource.Play ();
	}
	public static void Play(AudioClip song){
		audioManager.play (song);
	}
}

﻿using UnityEngine;
using System.Collections;

public class ExplosionController : MonoBehaviour {
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (!animator.animation.isPlaying)
		//	Destroy (this.gameObject);
	}
}

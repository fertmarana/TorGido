﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUP : MonoBehaviour {

	public int Increase;
	public GameObject Tor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			Tor.gameObject.GetComponent<StatsManager> ().damage += Increase;
			Destroy (gameObject);
		}
	}
}
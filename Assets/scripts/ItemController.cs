﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

	Rigidbody2D rigid2d;

	// Use this for initialization
	void Start () {
		rigid2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// transform.Translate(-1.0f,0,0);
		transform.Translate(-0.03f,0,0,Space.World);
		transform.Rotate(0,0,15.0f,Space.Self);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "bar"){
			Destroy(gameObject);
		}
	}
}

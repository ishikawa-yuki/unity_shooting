using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

	Rigidbody2D rigid2d;

	// Use this for initialization
	void Start () {
		rigid2d = GetComponent<Rigidbody2D>();
		this.rigid2d.AddForce(transform.right * -2.0f , ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		// transform.Translate(-1.0f,0,0);
		transform.Rotate(0,0,15.0f,Space.Self);
	}
}

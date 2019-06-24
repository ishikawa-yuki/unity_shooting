using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-8.0f * Time.deltaTime, 0, 0);
		if(transform.position.x < -18.0f){
			transform.position = new Vector3(0, 0, 0);
		}
	}
}

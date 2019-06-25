using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBackgroundController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-0.03f,0,0);
		if (transform.position.x < -20.0f){
			transform.position = new Vector3(20.0f,0,0);
		}
	}
}

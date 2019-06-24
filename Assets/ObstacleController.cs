using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {


	GameObject director;
	// Use this for initialization
	void Start () {
		this.director = GameObject.Find("GameDirector");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, 3.0f, Space.World);
		transform.Translate (-0.01f, 0, 0, Space.World);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "playerbullet" || other.gameObject.tag == "enemybullet"){
			Destroy(other.gameObject);
		}
	}
}

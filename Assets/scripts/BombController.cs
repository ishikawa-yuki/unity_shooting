using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

	GameObject director;
	float explosion_time = 1.2f ;
	float deltime = 0;

	// Use this for initialization
	void Start () {
		this.director = GameObject.Find("GameDirector");
	}
	
	// Update is called once per frame
	void Update () {
		deltime += Time.deltaTime;
		if (deltime >= explosion_time){
			Destroy(gameObject);
		}

		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "enemybullet"){
			Destroy(other.gameObject);
		}
	}

}

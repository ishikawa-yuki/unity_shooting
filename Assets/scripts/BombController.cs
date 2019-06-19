using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

	float explosion_time = 1.0f ;
	float deltime = 0;
	float vfx = 2.0f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		deltime += Time.deltaTime;
		if (deltime >= vfx){
			Destroy(gameObject);
		}

		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "enemy" || other.gameObject.tag == "enemybullet"){
			Destroy(other.gameObject);
		}
	}

}

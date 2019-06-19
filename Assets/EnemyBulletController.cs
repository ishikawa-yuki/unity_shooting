using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-0.1f, 0, 0);
	}

	// void OnCollisionEnter2D(Collision2D other){
		
	// }

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "player" || other.gameObject.tag == "playerbullet"){
			Destroy(other.gameObject);
			Destroy(gameObject);
		}

		if(other.gameObject.tag == "bar"){
			Destroy(gameObject);
		}
	}
}

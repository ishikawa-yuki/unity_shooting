using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyController : MonoBehaviour {

	float span = 0.5f;
	float delta = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		delta += Time.deltaTime;
		if(span < delta){
			delta = 0;
			transform.Translate(0, -0.3f, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "bar"){
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "playerbullet"){
			Destroy(gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

	GameObject director;

	// Use this for initialization
	void Start () {
		this.director = GameObject.Find("GameDirector");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-0.1f, 0, 0);
		if(this.director.GetComponent<GameDirector>().boss_sine){
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "bar"){
			Destroy(gameObject);
		}
	}
}

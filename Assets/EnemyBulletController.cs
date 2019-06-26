using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

	GameObject director;

	// Use this for initialization
	void Start () {
		this.director = GameObject.Find("GameDirector");
		if(this.director.GetComponent<GameDirector>().boss_sine){
			this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0);
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-5.0f * Time.deltaTime, 0, 0);
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

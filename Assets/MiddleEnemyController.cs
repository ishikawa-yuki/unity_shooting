using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleEnemyController : MonoBehaviour {

	public GameObject EnemyBulletPrefab;
	float moveSpan = 0.5f;
	float moveDelta = 0;
	float shootSpan = 1.5f;
	float shootDelta = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-0.01f, 0, 0);
		shootDelta += Time.deltaTime;
		if(shootSpan < shootDelta){
			shootDelta = 0;
			Instantiate (EnemyBulletPrefab, transform.position, Quaternion.identity);
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

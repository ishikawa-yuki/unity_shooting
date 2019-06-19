using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyController : MonoBehaviour {

	public GameObject EnemyBulletPrefab;
	float delta = 0;		float moveSpan = 0.5f;
	float moveDelta = 0;
	float shootSpan = 1.5f;
	float shootDelta = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		moveDelta += Time.deltaTime;
		if(span < delta){			shootDelta +=Time.deltaTime;
			delta = 0;			if(moveSpan < moveDelta){
			moveDelta = 0;
			transform.Translate(0, -0.3f, 0);
		}

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

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleEnemyController : MonoBehaviour {

	public GameObject EnemyBulletPrefab;
	public GameObject explosionPrefab;
	GameObject director;
	//スコア加算用メソッド呼び出しのためにオブジェクトを定義・取得予定
	int life = 7;
	float shootSpan = 1.5f;
	float shootDelta = 0;
	// Use this for initialization

	void Start () {
		this.director = GameObject.Find("GameDirector");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-1.0f * Time.deltaTime, 0, 0);
		shootDelta += Time.deltaTime;
		if(shootSpan < shootDelta){
			shootDelta = 0;
			Instantiate (EnemyBulletPrefab, transform.position, Quaternion.identity);
		}
	}

  void OnTriggerEnter2D(Collider2D other){

		if(other.gameObject.tag == "playerbullet"){
			this.life -= 1;
			if(this.life <= 0){
				GameObject effect = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
				Destroy(gameObject);
				this.director.GetComponent<GameDirector>().middleenemy_kill();
				//ToDo スコア加算用メソッド呼び出し追記予定
			}
		}

		if(other.gameObject.tag == "bomb"){
				GameObject effect = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
				Destroy(gameObject);
				this.director.GetComponent<GameDirector>().middleenemy_kill();
				//ToDo スコア加算用メソッド呼び出し追記予定
			}
		}

		if(other.gameObject.tag == "bar"){
			Destroy(gameObject);
		}

	}
}

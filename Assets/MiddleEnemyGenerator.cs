using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleEnemyGenerator : MonoBehaviour {

	public GameObject MiddleEnemyPrefab;
	GameObject director;
	float span = 0;
	float delta = 0;
	float enemyPosy = 4.0f;

	// Use this for initialization
	void Start () {
		this.director = GameObject.Find("GameDirector");
		int stageNum = this.director.GetComponent<GameDirector>().steage;
		switch (stageNum) {
			case 1:
				this.span = 15.0f;
				break;
			case 2:
				this.span = 12.0f;
				break;
			case 3:
				this.span = 10.0f;
				break;
			default:
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.delta += Time.deltaTime;
		if(this.span < this.delta){
			this.delta = 0;
			GameObject enemyGen = Instantiate(MiddleEnemyPrefab) as GameObject;
			enemyGen.transform.position = new Vector3(8, enemyPosy, 0);

			if(enemyPosy < -3.0f){
				enemyPosy = 4.0f;
			} else {
				enemyPosy -= 3.5f;
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleEnemyGenerator : MonoBehaviour {

	public GameObject MiddleEnemyPrefab;
	float span = 10.0f;
	float delta = 0;
	float enemyPosy = 4.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.delta += Time.deltaTime;
		if(this.span < this.delta){
			this.delta = 0;
			GameObject enemyGen = Instantiate(MiddleEnemyPrefab) as GameObject;
			enemyGen.transform.position = new Vector3(8, enemyPosy, 0);
			if(enemyPosy < -4.5f){
				enemyPosy = 4.0f;
			} else {
				enemyPosy -= 3.5f;
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyGenerator : MonoBehaviour {

	public GameObject NormalEnemyPrefab;
	float span = 4.0f;
	float delta = 0;
	float enemyPosy = 4.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.delta += Time.deltaTime;
		if(this.span < this.delta){
			this.delta = 0;
			GameObject enemyGen = Instantiate(NormalEnemyPrefab) as GameObject;
			enemyGen.transform.position = new Vector3(8, enemyPosy, 0);
			if(enemyPosy < -4.5f){
				enemyPosy = 4.5f;
			} else {
				enemyPosy -= 2.7f;
			}
		}
	}
}

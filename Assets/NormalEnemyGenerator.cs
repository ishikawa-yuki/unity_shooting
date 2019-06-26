using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyGenerator : MonoBehaviour {

	public GameObject NormalEnemyPrefab;
	GameObject director;
	GameDirector script;
	float span = 0;
	float stopSpan;
	//ボス出現前に雑魚の出現を停止するまでの時間を示す変数
	float delta = 0;
	float stopDelta = 0;
	float enemyPosy = 4.5f;

	// Use this for initialization
	void Start () {
		this.director = GameObject.Find("GameDirector");
		this.script = this.director.GetComponent<GameDirector>();
		int stageNum = this.script.stage;
		this.stopSpan = this.script.emergenceStopSpan;
		switch (stageNum) {
			case 1:
				this.span = stopSpan / 40.0f;
				break;
			case 2:
				this.span = stopSpan / 50.0f;
				break;
			case 3:
				this.span = stopSpan / 60.0f;
				break;
			default:
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.stopDelta += Time.deltaTime;
		if(stopDelta < stopSpan){
			this.delta += Time.deltaTime;
			if(this.span < this.delta){
				this.delta = 0;
				GameObject enemyGen = Instantiate(NormalEnemyPrefab) as GameObject;
				enemyGen.transform.position = new Vector3(8, enemyPosy, 0);
				if(enemyPosy < -3.0f){
					enemyPosy = 4.5f;
				} else {
					enemyPosy -= 2.7f;
				}
			}
		}
	}
}

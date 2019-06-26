﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

	public GameObject ObstaclePrefab;
	GameObject director;
	GameDirector script;
	float delta = 0;
	float stopDelta = 0;
	float span = 0;
	float stopSpan;
	float ObstaclePosy = 3.5f;
	int stageNum = 0;
	// Use this for initialization
	void Start () {
		this.director = GameObject.Find("GameDirector");
		this.script = this.director.GetComponent<GameDirector>();
		this.stageNum = this.script.stage;
		this.stopSpan = this.script.emergenceStopSpan;
		switch (stageNum) {
			case 1:
				this.span = 12.0f;
				break;
			case 2:
				this.span = 13.5f;
				break;
			case 3:
				this.span = 14.0f;
				break;
			default:
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.stopDelta += Time.deltaTime;
		if(this.stopDelta < this.stopSpan){
			this.delta += Time.deltaTime;
			if(this.delta >= this.span){
				Debug.Log("stopspan : " + this.stopSpan);
				Debug.Log("stage : " + this.stageNum);
				this.delta = 0;
				GameObject ObstacleGen = Instantiate(ObstaclePrefab) as GameObject;
				ObstacleGen.transform.position = new Vector3(8, ObstaclePosy, 0);
				if(ObstaclePosy < -2.0f){
					ObstaclePosy = 3.5f;
				} else {
					ObstaclePosy *= -1.0f;
				}
			}
		}
	}
}

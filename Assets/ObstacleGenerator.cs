using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

	float delta = 0;
	float stopDelta = 0;
	float span = 9.0f;
	float stopSpan = 20.0f;
	float ObstaclePosy = 3.5f;
	public GameObject ObstaclePrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.stopDelta += Time.deltaTime;
		if(stopDelta < stopSpan){
			this.delta += Time.deltaTime;
			if(this.span < this.delta){
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorksGenerator : MonoBehaviour {

	float fireworks_interval = 0.5f;

	float fireworks_check = 0;

	public GameObject fireworksPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.fireworks_check += Time.deltaTime;
		if(this.fireworks_check > this.fireworks_interval){
			this.fireworks_check = 0;
			GameObject fireworks = Instantiate(fireworksPrefab) as GameObject;
			float fireworks_lanch_position_x = Random.Range(-7,7);
			float fireworks_lanch_position_y = Random.Range(-2.5f,3.5f);
			fireworks.transform.position = new Vector3(fireworks_lanch_position_x, fireworks_lanch_position_y, 0);
		}
	}
}

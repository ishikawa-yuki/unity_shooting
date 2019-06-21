using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGeneratot : MonoBehaviour {

	public GameObject bossPrefab;
	float span = 30.0f;
	float delta = 0;
	int onlyBoss;
	// Use this for initialization
	void Start () {
		onlyBoss = 0;
	}
	
	// Update is called once per frame
	void Update () {
		this.delta += Time.deltaTime;
		Debug.Log(this.delta);
		if( this.onlyBoss == 0){
			if(this.delta >= this.span){
				GameObject bossgen = Instantiate(bossPrefab) as GameObject;
				bossgen.transform.position = new Vector3(0, 0, 0);
				this.onlyBoss = 1;
			}
		}
	}
}

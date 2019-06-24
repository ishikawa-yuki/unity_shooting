using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGeneratot : MonoBehaviour {

	public GameObject bossPrefab;
	GameObject director;
	GameDirector script;
	float span;
	float delta = 0;
	int onlyBoss;
	// Use this for initialization
	void Start () {
		onlyBoss = 0;
		this.director = GameObject.Find("GameDirector");
		this.script = this.director.GetComponent<GameDirector>();
		this.span = this.script.emergenceStopSpan + 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(delta);
		this.delta += Time.deltaTime;
		if( this.onlyBoss == 0){
			if(this.delta >= this.span){
				GameObject bossgen = Instantiate(bossPrefab) as GameObject;
				bossgen.transform.position = new Vector3(20, 0, 0);
				this.onlyBoss = 1;
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour {

 	public Material sub3;
	GameObject director;
	GameDirector script;
	int stageNumber;
	float speed = 0.5f;
	// Use this for initialization
	void Start () {
		this.director = GameObject.Find("GameDirector");
		this.script = this.director.GetComponent<GameDirector>();
	}
	
	// Update is called once per frame
	void Update () {
			this.stageNumber = this.script.stage;
			float rotateSpeed = Mathf.Repeat(Time.time * this.speed, 1);
			Vector2 offset = new Vector2(rotateSpeed, 0);
		if(this.stageNumber == 3){
			GetComponent<Renderer>().sharedMaterial = sub3;
			GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
		}else{
			GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorksController : MonoBehaviour {
	float explosion_time = 1.2f ;
	float deltime = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.deltime += Time.deltaTime;
		if (this.deltime >= this.explosion_time){
			Destroy(gameObject);
		}
	}
}

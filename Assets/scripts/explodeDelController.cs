using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeDelController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ParticleSystem partcleSystem = GetComponent<ParticleSystem>() ;
		//Delete object after duration.
		Destroy(gameObject,(float)partcleSystem.main.duration ) ;
	}
}

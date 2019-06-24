using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		this.player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerpos = this.player.transform.position;
		transform.position = new Vector3(playerpos.x,playerpos.y,playerpos.z);
	}
}

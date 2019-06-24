using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, 30.0f * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other.gameObject.tag + "に当たりました");
		if (other.gameObject.tag == "bar" || other.gameObject.tag == "enemy" || other.gameObject.tag == "boss"){
			Destroy(gameObject);
		}
	}
}

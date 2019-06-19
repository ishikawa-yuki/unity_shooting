using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0,0.3f,0);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other.gameObject.tag + "に当たりました");
		if (other.gameObject.tag == "bar"){
			Destroy(gameObject);
		}	
	}
}

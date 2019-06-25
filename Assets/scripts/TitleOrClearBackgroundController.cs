using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleOrClearBackgroundController : MonoBehaviour {

	public float speed = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.Repeat(Time.time * this.speed, 1);
		Vector2 offset = new Vector2(x, 0);
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
		// transform.Translate(-0.03f,0,0);
		// if (transform.position.x < -20.0f){
		// 	transform.position = new Vector3(20.0f,0,0);
		// }
	}
}

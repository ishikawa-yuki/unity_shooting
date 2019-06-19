using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rigid2d;
	public GameObject playerbulletPrefab;
	public float deltime = 0;

	float span = 0.1f;


	// Use this for initialization
	void Start () {
		rigid2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow)){
			transform.Translate(-0.1f,0,0);
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			transform.Translate(0.1f,0,0);
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate(0,-0.1f,0);
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			transform.Translate(0,0.1f,0);
		}
		if (Input.GetKey(KeyCode.Space)){
			this.deltime += Time.deltaTime;
			if (this.deltime >= this.span ){
				this.deltime = 0;
				GameObject bullet = Instantiate(playerbulletPrefab) as GameObject;
				bullet.transform.position = new Vector3(transform.position.x + 1.0f,transform.position.y,transform.position.z);	
			}
		}
	}
}

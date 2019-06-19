using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject playerbulletPrefab;
	public float deltime = 0;
	float span = 0.2f;
	int bullet_type = 0;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow)){
			if(transform.position.y < 4.5f){
				transform.Translate(-0.1f,0,0);
			}
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			if (transform.position.y > -4.5f){
				transform.Translate(0.1f,0,0);	
			}
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			if (transform.position.x > -7.5f){
				transform.Translate(0,-0.1f,0);
			}
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			if (transform.position.x < 7.5f ){
				transform.Translate(0,0.1f,0);
			}
		}
		if (Input.GetKey(KeyCode.Space)){
			this.deltime += Time.deltaTime;
			if (this.deltime >= this.span ){
				this.deltime = 0;
				switch (this.bullet_type){

					case 1:
					 GameObject bullet1 = Instantiate(playerbulletPrefab) as GameObject;
					 GameObject bullet2 = Instantiate(playerbulletPrefab) as GameObject;
					 bullet1.transform.position = new Vector3(transform.position.x + 1.0f,transform.position.y + 0.5f,transform.position.z);
					 bullet2.transform.position = new Vector3(transform.position.x + 1.0f,transform.position.y - 0.5f,transform.position.z);
					 break;

					default:
					GameObject bullet = Instantiate(playerbulletPrefab) as GameObject;
					bullet.transform.position = new Vector3(transform.position.x + 1.0f,transform.position.y,transform.position.z);
					break;
				}

			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other.gameObject.tag + "に自機が重なりました");
		if (other.gameObject.tag == "item"){
			Destroy(other.gameObject);
			this.bullet_type = 1;
		}
	}
}

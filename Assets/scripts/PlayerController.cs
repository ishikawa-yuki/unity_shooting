using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject playerbulletPrefab;
	public GameObject bombPrefab;
	public GameObject barrierPrefab;
	public GameObject explosionPrefab;
	GameObject gamedirector;
	public float deltime = 0;
	float span = 0.2f;
	public int bullet_type = 0;

	bool explodeControll;
	public bool barrier_flag = false;


	// Use this for initialization
	void Start () {
		this.gamedirector = GameObject.Find("GameDirector");
		this.bullet_type = PlayerPrefs.GetInt("bullet_mode",0);
		this.explodeControll = true;
		this.barrier_flag = PlayerPrefs.GetInt("barrier_mode") == 1 ? true : false ;
		if (this.barrier_flag){
			GameObject barrier = Instantiate(barrierPrefab) as GameObject;
			barrier.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(explodeControll){
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
				if(transform.position.y < 4.5f){
					transform.Translate(-0.1f,0,0);
				}
			}
			if (Input.GetKey(KeyCode.DownArrow ) || Input.GetKey(KeyCode.S)){
				if (transform.position.y > -4.5f){
					transform.Translate(0.1f,0,0);	
				}
			}
			if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
				if (transform.position.x > -7.5f){
					transform.Translate(0,-0.1f,0);
				}
			}
			if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
				if (transform.position.x < 7.5f ){
					transform.Translate(0,0.1f,0);
				}
			}
			this.deltime += Time.deltaTime;
			if (Input.GetKey(KeyCode.Space)){
				if (this.deltime >= this.span ){
					this.deltime = 0;
					switch (this.bullet_type){

						case 0:
							GameObject bullet = Instantiate(playerbulletPrefab) as GameObject;
							bullet.transform.position = new Vector3(transform.position.x + 1.0f,transform.position.y,transform.position.z);
							break;
						
						case 1:
							GameObject bullet1 = Instantiate(playerbulletPrefab) as GameObject;
							GameObject bullet2 = Instantiate(playerbulletPrefab) as GameObject;
							bullet1.transform.position = new Vector3(transform.position.x + 1.0f,transform.position.y + 0.5f,transform.position.z);
							bullet2.transform.position = new Vector3(transform.position.x + 1.0f,transform.position.y - 0.5f,transform.position.z);
							break;


						case 2:
							GameObject bullet3 = Instantiate(playerbulletPrefab) as GameObject;
							GameObject bullet4 = Instantiate(playerbulletPrefab) as GameObject;
							GameObject bullet5 = Instantiate(playerbulletPrefab) as GameObject;
							bullet3.transform.position = new Vector3(transform.position.x + 1.0f,transform.position.y,transform.position.z);
							bullet4.transform.position = new Vector3(transform.position.x + 1.0f,transform.position.y + 0.5f,transform.position.z);
							bullet5.transform.position = new Vector3(transform.position.x + 1.0f,transform.position.y - 0.5f,transform.position.z);
							break;
					}

				}
			}
			if (Input.GetKeyDown(KeyCode.B)){
				if (this.gamedirector.GetComponent<GameDirector>().bombstock >= 1){
					GameObject bomb = Instantiate(bombPrefab) as GameObject;
					bomb.transform.position = new Vector3(0,0,0);
					this.gamedirector.GetComponent<GameDirector>().bomb();
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other.gameObject.tag + "に自機が重なりました");
		if (other.gameObject.tag == "item"){
			Destroy(other.gameObject);
			if(this.bullet_type < 2){
				this.bullet_type += 1;
			}
		}
		if (other.gameObject.tag == "barrieritem"){
			Destroy(other.gameObject);
			Debug.Log(this.barrier_flag);
			if (!(this.barrier_flag)){
				GameObject barrier = Instantiate(barrierPrefab) as GameObject;
				barrier.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
				this.barrier_flag = true;	
			}
		}
		if (other.gameObject.tag == "enemybullet" || other.gameObject.tag == "enemy" || other.gameObject.tag == "boss" || other.gameObject.tag == "obstacle"){
			if (!(other.gameObject.tag == "obstacle")){
				Destroy(other.gameObject);
			}
			if (this.barrier_flag){
				Destroy(GameObject.FindGameObjectWithTag("barrier"));
				this.barrier_flag = false;
			}else{
				this.explodeControll = false;
				Instantiate(explosionPrefab, transform.position, Quaternion.identity);
				Invoke("DiePlayerEffect",0.2f);
			}
		}
	}

	void DiePlayerEffect(){
		Destroy(gameObject);
		PlayerPrefs.SetInt("bullet_mode",0);
		this.gamedirector.GetComponent<GameDirector>().player_kill();
	}
}

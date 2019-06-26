using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour {

	float move_speed = 2.0f;
	int movepara = 0;
	float shotdelt = 0;
	float span = 1.2f;
	public GameObject enemybulletPrefab;
	public GameObject explosionPrefab;

	GameObject gamedirector;
	GameObject stageClear;
	public int hp = 200;
	public int steage = 0;
	float beam_time = 1.0f;
	float beam_nowtime = 0;
	float beam_cast = 0;
	float beam_recast = 5.0f;
	bool admission = false;

	// Use this for initialization
	void Start () {
		this.gamedirector = GameObject.Find("GameDirector");
		this.steage = this.gamedirector.GetComponent<GameDirector>().stage;
		this.stageClear = GameObject.Find("StageClear");
	}
	
	// Update is called once per frame
	void Update () {
		if (admission){
			if(this.movepara == 0){
				System.Random py = new System.Random();
				this.movepara = py.Next(5);
			}

			switch (this.movepara){
				case 1:
					transform.Translate(0, move_speed * Time.deltaTime, 0);
					if (transform.position.y > 3){
						movepara = 0;
					}
					break;
				case 2:
					transform.Translate(0, -move_speed * Time.deltaTime, 0);
					if (transform.position.y < -3){
						movepara = 0;
					}
					break;

				case 3:
					transform.Translate(move_speed * Time.deltaTime, 0, 0);
					if (transform.position.x > 5.5){
						movepara = 0;
					}
					break;
				
				case 4:
					transform.Translate(-move_speed * Time.deltaTime, 0, 0);
					if (transform.position.x < 0){
						movepara = 0;
					}
					break;

				default:
				break;
			}

			this.shotdelt += Time.deltaTime;
			if(this.shotdelt >= this.span){
				this.shotdelt = 0;
				if(this.steage >= 1){
					Debug.Log(steage);
					GameObject bullet1 = Instantiate(enemybulletPrefab) as GameObject;
					GameObject bullet2 = Instantiate(enemybulletPrefab) as GameObject;
					GameObject bullet3 = Instantiate(enemybulletPrefab) as GameObject;
					GameObject bullet4 = Instantiate(enemybulletPrefab) as GameObject;
					bullet1.transform.position = new Vector3(transform.position.x - 2.0f,transform.position.y+0.5f,0);
					bullet2.transform.position = new Vector3(transform.position.x - 2.0f,transform.position.y-0.5f,0);
					bullet3.transform.position = new Vector3(transform.position.x - 1.5f,transform.position.y+1.3f,0);
					bullet4.transform.position = new Vector3(transform.position.x - 1.5f,transform.position.y-1.3f,0);
				}
				if(this.steage >= 2){
					Debug.Log(this.steage);
					Vector3 bulletPos1 = new Vector3(transform.position.x - 2.0f, transform.position.y + 0.5f,0);
					Instantiate(enemybulletPrefab, bulletPos1, Quaternion.Euler(0, 0, -20));
					Vector3 bulletPos2 = new Vector3(transform.position.x - 2.0f, transform.position.y - 0.5f,0);
					Instantiate(enemybulletPrefab, bulletPos2, Quaternion.Euler(0, 0, 20));
					Vector3 bulletPos3 = new Vector3(transform.position.x - 1.5f, transform.position.y + 1.3f,0);
					Instantiate(enemybulletPrefab, bulletPos3,Quaternion.Euler(0, 0, -20));
					Vector3 bulletPos4 = new Vector3(transform.position.x - 1.5f, transform.position.y - 1.3f,0);
					Instantiate(enemybulletPrefab, bulletPos4,Quaternion.Euler(0, 0, 20));
				}
			}
			if (this.steage >= 3){
				this.beam_cast += Time.deltaTime;
				if (beam_cast >= beam_recast){
					this.beam_nowtime+= Time.deltaTime;
					if (this.beam_nowtime > this.beam_time){
						this.beam_nowtime = 0;
						this.beam_cast = 0;
					}
					GameObject beam = Instantiate(enemybulletPrefab) as GameObject;
					beam.transform.position = new Vector3(transform.position.x - 2.0f,transform.position.y,0);
				}
			}
		}else{
			transform.Translate(-7.0f * Time.deltaTime,0,0);
			if (transform.position.x <= 0){
				this.admission = true;	
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "playerbullet"){
			this.hp--;
			if (this.hp <= 0){
				GameObject effect = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
				this.gamedirector.GetComponent<GameDirector>().sine();
				this.GetComponent<BoxCollider2D>().enabled = false;
				this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0);
				
				this.stageClear.GetComponent<Text>().text = "STAGE CLEAR";
				Invoke("DieEffect", 5);
			}	
		}
	}

	void DieEffect(){
		this.gamedirector.GetComponent<GameDirector>().boss_kill();
		Destroy(gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
	GameObject scoreText;
	GameObject stockText;
	GameObject bombstockText;
	GameObject stageText;
	GameObject player;
	public int bombstock = 1;
	public int stock = 3;
	int score =0;
	public int stage = 1;
	public float delt = 0;
	float stage_put = 3.0f;
	bool clear_flag = false;


	public void player_kill (){
		this.stock--;
		PlayerPrefs.SetInt("scoredata", this.score);
		PlayerPrefs.SetInt("stockdata", this.stock);
		if (this.stock <= 0){
			SceneManager.LoadScene("TitleScene");
		}else{
			SceneManager.LoadScene("GameScene");
		}
		
	}

	public void nomalenemy_kill(){
		this.score += 100;
	}

	public void middleenemy_kill(){
		this.score += 700;
	}

	public void boss_kill(){
		this.score += 1000;
		this.clear_flag = true;
	}

	public void stageclear(){
		this.stage += 1;
	}

	public void bomb(){
		this.bombstock--;
	}

	// Use this for initialization
	void Start () {
		this.scoreText = GameObject.Find("score");
		this.stage = PlayerPrefs.GetInt("clearflag",1);
		this.stockText = GameObject.Find("stock");
		this.bombstockText = GameObject.Find("bomb_stock");
		this.stageText = GameObject.Find("stage");
		this.player = GameObject.Find("player");
		this.score = PlayerPrefs.GetInt("scoredata",0);
		this.stock = PlayerPrefs.GetInt("stockdata",3);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.delt <= this.stage_put){
			this.delt += Time.deltaTime;
			this.stageText.GetComponent<Text>().text = "STAGE" + this.stage;
		}else{
			this.stageText.GetComponent<Text>().text = "";
		}
		this.scoreText.GetComponent<Text>().text = "score : " + this.score;
		this.bombstockText.GetComponent<Text>().text = "bomb : " + this.bombstock;
		this.stockText.GetComponent<Text>().text = "stock : " + this.stock;
		if(this.clear_flag){
			PlayerPrefs.SetInt("scoredata", this.score);
			PlayerPrefs.SetInt("stockdata", this.stock);
			this.stage++;
			PlayerPrefs.SetInt("clearflag", this.stage);
			PlayerPrefs.SetInt("bullet_mode", this.player.GetComponent<PlayerController>().bullet_type);
			SceneManager.LoadScene("GameScene");
		}

		if(stage == 4){
			PlayerPrefs.SetInt("scoredata", this.score);;
			SceneManager.LoadScene("ClearScene");
		}

	}
}

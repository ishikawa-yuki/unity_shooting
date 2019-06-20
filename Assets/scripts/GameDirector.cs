using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
	GameObject scoreText;
	GameObject stockText;
	GameObject bombstockText;
	public int bombstock = 1;
	public int stock = 3;
	public int steage = 1;
	int score =0;
	int stage = 1;
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
		score += 100;
	}

	public void middleenemy_kill(){
		score += 700;
	}

	public void stageclear(){
		stage += 1;
	}

	public void bomb(){
		bombstock--;
	}

	// Use this for initialization
	void Start () {
		this.scoreText = GameObject.Find("score");
		this.stage = PlayerPrefs.GetInt("clearflag",1);
		this.stockText = GameObject.Find("stock");
		this.bombstockText = GameObject.Find("bomb_stock");
		this.score = PlayerPrefs.GetInt("scoredata",0);
		Debug.Log(PlayerPrefs.GetInt("scoredata",0));
		this.stock = PlayerPrefs.GetInt("stockdata",3);
	}
	
	// Update is called once per frame
	void Update () {
		this.scoreText.GetComponent<Text>().text = "score : " + this.score;
		this.bombstockText.GetComponent<Text>().text = "bomb : " + this.bombstock;
		this.stockText.GetComponent<Text>().text = "stock : " + this.stock;
		if(this.clear_flag){
			PlayerPrefs.SetInt("scoredata", this.score);
			PlayerPrefs.SetInt("stockdata", this.stock);
			PlayerPrefs.SetInt("clearflag", this.stage);
			SceneManager.LoadScene("GameScene");
		}

		if(stage == 4){
			PlayerPrefs.SetString("scoredata", this.scoreText.GetComponent<Text>().text);
			SceneManager.LoadScene("ClearScene");
		}

		if (stock <= 0){
			// SceneManager.LoadScene("TitleScene");
		}
		
	}
}

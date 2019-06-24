using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour {

	int score = 0;

	int stock = 0;

	GameObject clearText;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		this.clearText = GameObject.Find("clear");
		this.stock = PlayerPrefs.GetInt("stockdata");
		this.score = PlayerPrefs.GetInt("scoredata");
	}
	
	// Update is called once per frame
	void Update () {
		this.clearText.GetComponent<Text>().text = this.score + "X" + this.stock + "\nSCORE : " + this.score*this.stock + "\nEnterキーでタイトルへ";
		if (Input.GetKeyDown(KeyCode.Return)){
			SceneManager.LoadScene("TitleScene");
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		PlayerPrefs.DeleteAll();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)){
			SceneManager.LoadScene("GameScene");
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	public GameObject itemPrefab;
	public float deltime = 0;
	float span = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.deltime += Time.deltaTime;
		if (this.deltime >= this.span){
			this.deltime = 0;
			GameObject item = Instantiate(itemPrefab) as GameObject;
			int py = Random.Range(4,-4);
			item.transform.position = new Vector3(8, py, 0);
		}
	}
}

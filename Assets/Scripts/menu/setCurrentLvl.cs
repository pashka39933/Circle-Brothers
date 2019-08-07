using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class setCurrentLvl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Text> ().text = "Poziom " + global.currentLevel; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

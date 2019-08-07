using UnityEngine;
using System.Collections;

public class firstSceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll ();
		global.currentLevel = PlayerPrefs.GetInt("currentLevel", 0);
		if(global.currentLevel == 0)
			Application.LoadLevel("intro");
		else
			Application.LoadLevel("menu");
	}
	
	// Update is called once per frame
	void Update () {
	}
}

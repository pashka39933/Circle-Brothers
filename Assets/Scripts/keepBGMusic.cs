using UnityEngine;
using System.Collections;

public class keepBGMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Object.DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName != "intro" && Application.loadedLevelName != "firstScene") {
			this.GetComponent<AudioSource> ().enabled = true;
		} else {
			this.GetComponent<AudioSource> ().enabled = false;
		}
	}
}

using UnityEngine;
using System.Collections;

public class creditsEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.y >= 780)
			Application.LoadLevel("menu");
	}
}

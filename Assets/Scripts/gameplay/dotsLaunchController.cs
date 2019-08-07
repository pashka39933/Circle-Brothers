using UnityEngine;
using System.Collections;

public class dotsLaunchController : MonoBehaviour {

	GameObject[] dots;
	float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		dots = GameObject.FindGameObjectsWithTag("ENEMY");
		for (int i=0; i<dots.Length; i++) {
			if(dots[i].GetComponent<enemyMovement>().launchTime + dots[i].GetComponent<enemyMovement>().startTime < Time.timeSinceLevelLoad - startTime){
				dots[i].GetComponent<enemyMovement>().enabled = true;
			}
		}
	}
}

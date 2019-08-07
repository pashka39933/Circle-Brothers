using UnityEngine;
using System.Collections;

public class goodLuckOutCount : MonoBehaviour {

	public AnimationClip cueOut;
	public float goodLuckTime;
	public GameObject cam;
	public bool menuTutorial = false;
	float launchTime;
	bool animLaunched = false;

	// Use this for initialization
	void Start () {
		launchTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - launchTime >= goodLuckTime && !animLaunched) {
			this.GetComponent<Animation>().clip = cueOut;
			this.GetComponent<Animation>().Play();
			animLaunched = true;
		}
		if (!this.GetComponent<Animation>().isPlaying && animLaunched) {
			if(!menuTutorial){
				cam.GetComponent<animationLaunch>().enabled = true;
			}else{
				cam.GetComponent<fadingTutorial>().destCol = cam.GetComponent<fadingTutorial>().solid;
				cam.GetComponent<fadingTutorial>().lvlChange = true;
			}
			this.GetComponent<goodLuckOutCount>().enabled = false;
		}
	}
}

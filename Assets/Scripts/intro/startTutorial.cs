using UnityEngine;
using System.Collections;

public class startTutorial : MonoBehaviour {

	public GameObject blue, green, circle, island;
	public float startTime;
	float launchTime;
	bool animPlayed = false;
	
	void Start(){
		launchTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad - launchTime > startTime && !animPlayed) {
			Animation anim = blue.GetComponent<Animation>();
			anim.wrapMode = WrapMode.Once;
			anim.Play();
			anim = green.GetComponent<Animation>();
			anim.wrapMode = WrapMode.Once;
			anim.Play();
			anim = circle.GetComponent<Animation>();
			anim.wrapMode = WrapMode.Once;
			anim.Play();
			anim = island.GetComponent<Animation>();
			anim.wrapMode = WrapMode.Once;
			anim.Play();
			animPlayed = true;
		}
		if (animPlayed) {
			if(!blue.GetComponent<Animation>().isPlaying){
				Application.LoadLevel("0");
			}
		}
	}
}

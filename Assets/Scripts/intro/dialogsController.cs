using UnityEngine;
using System.Collections;

public class dialogsController : MonoBehaviour {

	public GameObject[] dialogs;
	public float[] startTimes, lengths; 
	int iterator = 0;
	float launchTime;
	bool dialogVisible;

	// Use this for initialization
	void Start () {
		launchTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad - launchTime >= startTimes [iterator] && !dialogVisible) {
			Animation anim = dialogs [iterator].GetComponent<Animation> ();
			anim.clip = anim.GetClip ("dialogIn");
			anim["dialogIn"].speed = 2;
			anim.wrapMode = WrapMode.Once;
			anim.Play ();
			dialogVisible = true;
			this.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Sounds/dialog"));
		} else
		if (Time.timeSinceLevelLoad - startTimes [iterator] > lengths [iterator] && dialogVisible) {
			Animation anim = dialogs [iterator].GetComponent<Animation> ();
			anim.clip = anim.GetClip ("dialogOut");
			anim["dialogOut"].speed = 2;
			anim.wrapMode = WrapMode.Once;
			anim.Play ();
			dialogVisible = false;
			if(iterator < dialogs.Length-1)
				iterator++;
			else
				this.GetComponent<dialogsController>().enabled = false;
		}
	}
}

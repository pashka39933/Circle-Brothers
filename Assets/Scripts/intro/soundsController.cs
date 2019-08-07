using UnityEngine;
using System.Collections;

public class soundsController : MonoBehaviour {

	public AudioSource source1, source2;
	public GameObject star, wrod;
	float startTime;
	bool explosionPlayed = false, wrodFlyLaunched = false, countStart = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (star.transform.position.y < -1150 && !explosionPlayed) { 
			source1.Stop();
			source1.clip = (AudioClip)Resources.Load("Sounds/wrod");
			source1.loop = true;
			source1.pitch = 0.85f;
			source1.volume = 0.3f;
			source2.clip = (AudioClip)Resources.Load("Sounds/explosion2");
			source2.volume = 1;
			source2.PlayOneShot(source2.clip);
			explosionPlayed = true;
			countStart = true;
			startTime = Time.timeSinceLevelLoad;
		}
		if (countStart && Time.timeSinceLevelLoad - startTime > 5) {
			source1.Play();
			countStart = false;
		}
		if (wrod.GetComponent<Animation> ().isPlaying && !wrodFlyLaunched) {
			wrod.GetComponent<AudioSource>().volume = 0.3f;
			wrod.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Sounds/wrodLaunch1"));
			wrodFlyLaunched = true;
		}
		if (!this.GetComponent<wrodCatchController> ().enabled) {
			source1.volume = Mathf.Lerp(source1.volume, 0, 0.015f);
			if(source1.volume == 0)
				this.GetComponent<soundsController>().enabled = false;
		}
	}
}
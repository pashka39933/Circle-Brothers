using UnityEngine;
using System.Collections;

public class buttonClicks : MonoBehaviour {

	public GameObject circle, brothers, fade, canv;
	bool yesClicked = false, noClicked = false, circleLoading = false;

	void Update(){
		if (yesClicked) {
			if (!fade.GetComponent<Animation> ().isPlaying && !circleLoading) {
				canv.SetActive (false);
				circle.SetActive (true);
				brothers.SetActive (true);
				global.rot = Vector3.zero;
				brothers.transform.localEulerAngles = global.rot;
				fade.GetComponent<Animation> ().Play ("fadeIn");
				circleLoading = true;
			}
			else if (!fade.GetComponent<Animation>().isPlaying && circleLoading){
				Application.LoadLevel(global.lastLevelLoaded);
			}
		} else if (noClicked) {
			if(!fade.GetComponent<Animation>().isPlaying){
				Application.LoadLevel("menu");
			}
		}
	}

	public void loadLastLevel(){
		this.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Sounds/pop1"));
		fade.GetComponent<Animation>().Play("fadeOut");
		yesClicked = true;
	}

	public void loadMenu(){
		this.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Sounds/pop1"));
		fade.GetComponent<Animation>().Play("fadeOut");
		noClicked = true;
	}
}

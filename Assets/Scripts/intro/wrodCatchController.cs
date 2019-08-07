using UnityEngine;
using System.Collections;

public class wrodCatchController : MonoBehaviour {

	public GameObject wrod, yola, star, shadow;
	public float outAnimationTime;
	public Color darkIslandColor;
	float launchTime;

	void Start(){
		launchTime = Time.timeSinceLevelLoad;
	}

	// Update is called once per frame
	void Update () {
		if (star.transform.localScale.x > 500 && star.transform.localScale.y > 500) {
			wrod.SetActive(true);
			yola.SetActive(false);
			shadow.SetActive(true);
		}
		if (Time.timeSinceLevelLoad - launchTime > outAnimationTime) {
			Animation anim = wrod.GetComponent<Animation>();
			anim.wrapMode = WrapMode.Once;
			anim.clip = anim.GetClip("WrodOut");
			anim.Play();
			this.GetComponent<wrodCatchController>().enabled = false;
		}
	}
}

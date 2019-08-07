using UnityEngine;
using System.Collections;

public class lvlAnimContorller : MonoBehaviour {
	
	Animation anim;
	public float animationSpeed;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animation> ();
		anim.wrapMode = WrapMode.Once;
		anim [anim.clip.name].speed = animationSpeed;
		anim.Play();
		global.rdyToChangeLvl = true;
		this.GetComponent<lvlAnimContorller>().enabled = false;
	}
}

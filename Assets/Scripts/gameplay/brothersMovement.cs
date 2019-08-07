using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class brothersMovement : MonoBehaviour {

	public GameObject blueBrother, greenBrother, Canv;
	SkeletonAnimation blueAnim, greenAnim;
	public float brothersSpeed;
	public bool disableCollision;

	// Use this for initialization
	void Start () {
		blueAnim = blueBrother.GetComponent<SkeletonAnimation> ();
		greenAnim = greenBrother.GetComponent<SkeletonAnimation> ();
		blueAnim.timeScale = brothersSpeed / 40;
		greenAnim.timeScale = brothersSpeed / 40;
		this.transform.localEulerAngles = global.rot;
		Canv.SetActive (true);
		if (Application.loadedLevelName.Length < 3) {
			global.currentLevel = int.Parse (Application.loadedLevelName);
		}
		blueBrother.AddComponent<AudioSource> ();
		greenBrother.AddComponent<AudioSource> ();
		blueBrother.GetComponent<AudioSource> ().playOnAwake = false;
		greenBrother.GetComponent<AudioSource> ().playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (disableCollision) {
			blueBrother.GetComponent<BoxCollider2D>().enabled = false;
			greenBrother.GetComponent<BoxCollider2D>().enabled = false;
		}
		Vector3 rot = this.transform.localEulerAngles;
		Vector3 blueRot = blueBrother.transform.localEulerAngles;
		Vector3 greenRot = greenBrother.transform.localEulerAngles;
		if (Input.GetKey (KeyCode.RightArrow) || (Input.touchCount > 0 && Input.GetTouch(0).position.x > Screen.width/2)) {
			if(greenBrother.transform.parent == this.transform){
				greenAnim.AnimationName = "run";
				greenRot.y = 0;
			}
			if(blueBrother.transform.parent == this.transform){
				blueAnim.AnimationName = "run";
				blueRot.y = 180;
			}
			rot.z -= (brothersSpeed * Time.deltaTime);
		} else
		if (Input.GetKey (KeyCode.LeftArrow) || (Input.touchCount > 0 && Input.GetTouch(0).position.x < Screen.width/2)) {
			if(greenBrother.transform.parent == this.transform){
				greenAnim.AnimationName = "run";
				greenRot.y = 180;
			}
			if(blueBrother.transform.parent == this.transform){
				blueAnim.AnimationName = "run";
				blueRot.y = 0;
			}
			rot.z += (brothersSpeed * Time.deltaTime);
		}
		else{
			if(blueBrother.transform.parent == this.transform)
				blueAnim.AnimationName = "idle";
			if(greenBrother.transform.parent == this.transform)
				greenAnim.AnimationName = "idle";
		}
		this.transform.localEulerAngles = rot;
		blueBrother.transform.localEulerAngles = blueRot;
		greenBrother.transform.localEulerAngles = greenRot;
		global.rot = this.transform.localEulerAngles;

		if (global.rdyToChangeLvl && !this.transform.GetComponentInChildren<Animation>().isPlaying) {
			global.rot = this.transform.localEulerAngles;
			global.rdyToChangeLvl = false;
			if(global.currentLevel < global.maxLevel)
				global.currentLevel++;
			PlayerPrefs.SetInt("currentLevel", global.currentLevel);
			Application.LoadLevel((global.currentLevel).ToString());
		}
	}
}

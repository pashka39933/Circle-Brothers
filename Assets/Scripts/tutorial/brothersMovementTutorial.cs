using UnityEngine;
using System.Collections;

public class brothersMovementTutorial : MonoBehaviour {

	public GameObject blueBrother, greenBrother, firstDot, secondDot, firstCue, secondCue, goodLuck;
	public AnimationClip cueIn, cueOut;
	SkeletonAnimation blueAnim, greenAnim;
	public float brothersSpeed;

	public bool leftWalk, rightWalk;
	
	// Use this for initialization
	void Start () {
		blueAnim = blueBrother.GetComponent<SkeletonAnimation> ();
		greenAnim = greenBrother.GetComponent<SkeletonAnimation> ();
		blueAnim.timeScale = brothersSpeed / 40;
		greenAnim.timeScale = brothersSpeed / 40;
		this.transform.localEulerAngles = global.rot;
		//global.currentLevel = int.Parse (Application.loadedLevelName.Substring (3, 1));
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rot = this.transform.localEulerAngles;
		Vector3 blueRot = blueBrother.transform.localEulerAngles;
		Vector3 greenRot = greenBrother.transform.localEulerAngles;
		if ((Input.GetKey (KeyCode.RightArrow) || (Input.touchCount > 0 && Input.GetTouch(0).position.x > Screen.width/2)) && rightWalk) {
			if(greenBrother.transform.parent == this.transform){
				greenAnim.AnimationName = "run";
				greenRot.y = 0;
			}
			if(blueBrother.transform.parent == this.transform){
				blueAnim.AnimationName = "run";
				blueRot.y = 180;
			}
			rot.z -= (brothersSpeed * Time.deltaTime);
			if(rot.z >= 355){
				secondCue.GetComponent<Animation>().clip = cueOut;
				secondCue.GetComponent<Animation>().Play();
				goodLuck.GetComponent<Animation>().Play();
				goodLuck.GetComponent<goodLuckOutCount>().enabled = true;
				secondDot.GetComponent<enemyTutorialMovement>().freezePos = Vector3.forward;
				secondDot.GetComponent<enemyTutorialMovement>().speed = 4;
				this.GetComponent<brothersMovement>().enabled = true;
				this.GetComponent<brothersMovementTutorial>().enabled = false;
			}
		} else
		if ((Input.GetKey (KeyCode.LeftArrow) || (Input.touchCount > 0 && Input.GetTouch(0).position.x < Screen.width/2)) && leftWalk) {
			if(greenBrother.transform.parent == this.transform){
				greenAnim.AnimationName = "run";
				greenRot.y = 180;
			}
			if(blueBrother.transform.parent == this.transform){
				blueAnim.AnimationName = "run";
				blueRot.y = 0;
			}
			rot.z += (brothersSpeed * Time.deltaTime);
			if(rot.z >= 45){
				firstCue.GetComponent<Animation>().clip = cueOut;
				firstCue.GetComponent<Animation>().Play();
				secondCue.GetComponent<Animation>().Play();
				leftWalk = false;
				firstDot.GetComponent<enemyTutorialMovement>().freezePos = Vector3.forward;
				firstDot.GetComponent<enemyTutorialMovement>().speed = 4;
				rightWalk = true;
			}
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
		
		//if (global.rdyToChangeLvl && !this.transform.GetComponentInChildren<Animation>().isPlaying) {
			//global.rot = this.transform.localEulerAngles;
			//global.rdyToChangeLvl = false;
			//Application.LoadLevel("lvl" + (global.currentLevel+1));
		//}
	}
}

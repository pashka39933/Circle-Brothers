using UnityEngine;
using System.Collections;

public class buttonClicked : MonoBehaviour {
	
	bool helpClicked = false, startClicked = false, startAnimationLaunched = false;
	public SpriteRenderer fade;
	public Color destCol;
	public GameObject circle, canv, blue, green, brothers, lvlName;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (helpClicked) {
			fade.color = Color.Lerp(fade.color, destCol, 0.3f);
			if(fade.color == destCol){
				global.rot = Vector3.zero;
				Application.LoadLevel("tutorialHelp");
			}
		}
		if (startClicked) {
			circle.GetComponent<Animation>().Play();
			canv.GetComponent<Animation>().Play();
			blue.GetComponent<Animation>().Play();
			green.GetComponent<Animation>().Play();
			lvlName.GetComponent<Animation>().Play();
			brothers.GetComponent<Animation>().Play();
			startAnimationLaunched = true;
			startClicked = false;
			brothers.GetComponent<brothersMovementMenu>().inCircle = true;
		}
		if (startAnimationLaunched && !lvlName.GetComponent<Animation>().isPlaying) {
			Application.LoadLevel(global.currentLevel.ToString());
		}
	}

	public void clickHelp(){
		helpClicked = true;
		this.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Sounds/pop1"));
	}

	public void clickStart(){
		startClicked = true;
		this.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Sounds/pop1"));
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class loadGameover : MonoBehaviour {

	public GameObject blue, green, fadeOutImg;
	bool animLaunched = false;

	// Use this for initialization
	void Start () {
		fadeOutImg.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
		global.lastLevelLoaded = Application.loadedLevel;
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (blue.transform.position.x) > 70 ||
			Mathf.Abs (green.transform.position.x) > 70 ||
			Mathf.Abs (blue.transform.position.y) > 110 ||
			Mathf.Abs (green.transform.position.y) > 110) {
			if(!animLaunched){
				fadeOutImg.GetComponent<Animation>().wrapMode = WrapMode.Once;
				fadeOutImg.GetComponent<Animation>().Play();
				animLaunched = true;
			} else if(!fadeOutImg.GetComponent<Animation>().isPlaying){
				Application.LoadLevel("gameover");
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class animationLaunch : MonoBehaviour {

	public GameObject[] objects;
	bool faded = false;

	// Use this for initialization
	void Start () {
		this.gameObject.AddComponent<camShake> ();
		camShake shake = this.GetComponent<camShake> ();
		shake.enabled = false;
		shake.decreaseFactor = 1;
		shake.shakeLength = 0.3f;
		shake.shakeAmount = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag("ENEMY").Length == 0) {
			for(int i=0; i<objects.Length; i++){
				if(global.currentLevel != global.maxLevel){
					objects[i].GetComponent<lvlAnimContorller>().enabled = true;
				} else {
					if(!faded){
						this.GetComponent<loadGameover>().fadeOutImg.GetComponent<Animation>().Play();
						faded = true;
					} else
					if(!this.GetComponent<loadGameover>().fadeOutImg.GetComponent<Animation>().isPlaying){
						Application.LoadLevel("outro");
					}
				}
			}
			if(global.currentLevel != global.maxLevel)
				this.GetComponent<animationLaunch>().enabled = false;
		}
	}
}

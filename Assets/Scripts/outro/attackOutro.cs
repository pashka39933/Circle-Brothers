using UnityEngine;
using System.Collections;

public class attackOutro : MonoBehaviour {

	public GameObject blue, wrodStart, wrodEnd, bat1, bat2, pow;
	public float attackTime;
	float startTime;
	bool animLaunched = false;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (attackTime < Time.time - startTime && !animLaunched) {
			blue.SetActive (true);
			wrodStart.SetActive (true);
			wrodEnd.SetActive (true);
			bat1.SetActive (true);
			bat2.SetActive (true);
			pow.SetActive (true);
			blue.GetComponent<SkeletonAnimation> ().loop = false;
			wrodStart.GetComponent<SkeletonAnimation> ().loop = false;
			wrodEnd.GetComponent<SkeletonAnimation> ().loop = false;
			bat1.GetComponent<SkeletonAnimation> ().loop = false;
			bat2.GetComponent<SkeletonAnimation> ().loop = false;
			pow.GetComponent<SkeletonAnimation> ().loop = false;
			blue.GetComponent<SkeletonAnimation> ().AnimationName = "attack";
			wrodStart.GetComponent<SkeletonAnimation> ().AnimationName = "attack";
			wrodEnd.GetComponent<SkeletonAnimation> ().AnimationName = "attack";
			bat1.GetComponent<SkeletonAnimation> ().AnimationName = "attack";
			bat2.GetComponent<SkeletonAnimation> ().AnimationName = "attack";
			pow.GetComponent<SkeletonAnimation> ().AnimationName = "attack";
			animLaunched = true;
		} else if (animLaunched && blue.GetComponent<SkeletonAnimation>().AnimationName == null) {
			blue.GetComponent<SkeletonAnimation>().loop = true;
			blue.GetComponent<SkeletonAnimation>().AnimationName = "idleAfter";
		}
	}
}

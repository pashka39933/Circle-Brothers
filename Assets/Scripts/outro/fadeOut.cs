using UnityEngine;
using System.Collections;

public class fadeOut : MonoBehaviour {

	public SpriteRenderer fade;
	public Color destCol;
	float startTime = 0;
	bool launch = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!this.GetComponent<dialogsController> ().enabled && !launch) {
			startTime = Time.time;
			launch = true;
		}
		if (launch && Time.time - startTime > 1) {
			fade.color = Color.Lerp(fade.color, destCol, 0.1f);
			if(fade.color == destCol){
				Application.LoadLevel("credits");
			}
		}
	}
}

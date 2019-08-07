using UnityEngine;
using System.Collections;

public class fadingTutorial : MonoBehaviour {

	public SpriteRenderer fade;
	public Color destCol, transparent, solid;
	public bool lvlChange = false;

	// Use this for initialization
	void Start () {
		destCol = transparent;
	}
	
	// Update is called once per frame
	void Update () {
		fade.color = Color.Lerp (fade.color, destCol, 0.3f);
		if (lvlChange && fade.color == destCol) {
			Application.LoadLevel("menu");
		}
	}
}

using UnityEngine;
using System.Collections;

public class keepBrothersCenter : MonoBehaviour {

	public GameObject cam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = cam.transform.position;
		pos.z = 0;
		this.transform.position = pos;
	}
}

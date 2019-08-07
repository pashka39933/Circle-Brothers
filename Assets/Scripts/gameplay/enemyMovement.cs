using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {

	public GameObject dot, target;
	public float startTime, speed, size, launchTime = 0;

	// Use this for initialization
	void Start () {
		target.transform.parent = this.transform.parent;
		this.transform.localScale = new Vector3 (size, size, size);
		this.GetComponent<CircleCollider2D> ().enabled = true;
		this.GetComponent<Rigidbody2D> ().isKinematic = true;
		this.GetComponent<enemyMovement> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dotPos = dot.transform.position;
		dotPos = Vector3.MoveTowards (dotPos, target.transform.position, speed);
		dot.transform.position = dotPos;
		if(Mathf.Abs(dotPos.x-target.transform.position.x) < 8 &&
		   Mathf.Abs(dotPos.y-target.transform.position.y) < 8){
			Destroy(target.gameObject);
			Destroy(this.gameObject);
		}
	}
}

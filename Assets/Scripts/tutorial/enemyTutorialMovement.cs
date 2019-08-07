using UnityEngine;
using System.Collections;

public class enemyTutorialMovement : MonoBehaviour {

	public GameObject dot, target;
	public float startTime, speed;
	float levelStartTime; 
	public Vector3 freezePos;
	
	// Use this for initialization
	void Start () {
		levelStartTime = Time.timeSinceLevelLoad;
		target.transform.parent = this.transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		if (startTime < Time.timeSinceLevelLoad - levelStartTime) {
			Vector3 dotPos = dot.transform.position;
			if(Mathf.RoundToInt(this.transform.position.x) != Mathf.RoundToInt(freezePos.x) ||
			   Mathf.RoundToInt(this.transform.position.y) != Mathf.RoundToInt(freezePos.y) ||
			   this.transform.position.z != freezePos.z){
				dotPos = Vector3.MoveTowards (dotPos, target.transform.position, speed);
			}
			dot.transform.position = dotPos;
			if(dotPos.Equals(target.transform.position)){
				if(target.transform.position.x == -32){
					GameObject.FindGameObjectWithTag("brothers").GetComponent<brothersMovementTutorial>().leftWalk = true;
					GameObject.FindGameObjectWithTag("brothers").GetComponent<brothersMovementTutorial>().rightWalk = true;
				}
				Destroy(target.gameObject);
				Destroy(this.gameObject);
				GameObject.FindGameObjectWithTag("ENEMY").GetComponent<enemyTutorialMovement>().freezePos = new Vector3(30,-30,0);
			}
		}
	}
}

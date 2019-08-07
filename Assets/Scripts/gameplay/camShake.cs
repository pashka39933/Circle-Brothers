using UnityEngine;
using System.Collections;

public class camShake : MonoBehaviour {
	
	public float shakeLength = 5;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	Vector3 initPos;

	void Start(){
		initPos = this.transform.position;
	}

	void Update() {
		if (shakeLength > 0) {
			Vector3 tmp = Random.insideUnitCircle * shakeAmount;
			tmp.z = initPos.z;
			this.GetComponent<Camera>().transform.localPosition = tmp;
			shakeLength -= Time.deltaTime * decreaseFactor;
			
		} else {
			this.transform.position = initPos;
			this.GetComponent<camShake>().enabled = false;
		}
	}

}

using UnityEngine;
using System.Collections;

public class collisionDetection : MonoBehaviour {

	public GameObject blue, green, brothers, cam;
	public SkeletonDataAsset orangeCollSD, blueCollSD;
	public Color orangeColor;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject == blue || coll.gameObject == green) {	
			Vector2 force = coll.contacts [0].point - (Vector2)this.transform.position;
			float sum = Mathf.Abs (force.x) + Mathf.Abs(force.y);
			force.x = force.x / sum;
			force.y = force.y / sum;
			coll.gameObject.GetComponent<AudioSource> ().pitch = 2;
			coll.gameObject.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Sounds/crash"));
			coll.gameObject.GetComponent<Rigidbody2D> ().AddForce (force * 3000);
			coll.gameObject.transform.parent = coll.gameObject.transform.parent.transform.parent;
			blue.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			green.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			blue.gameObject.GetComponent<SkeletonAnimation> ().AnimationName = "idle";
			green.gameObject.GetComponent<SkeletonAnimation> ().AnimationName = "idle";
			cam.GetComponent<animationLaunch> ().enabled = false;
			brothers.GetComponent<brothersMovement> ().enabled = false;
			if (this.GetComponent<SpriteRenderer> ().color == orangeColor)
				coll.gameObject.GetComponent<SkeletonAnimation> ().skeletonDataAsset = orangeCollSD;
			else 
				coll.gameObject.GetComponent<SkeletonAnimation> ().skeletonDataAsset = blueCollSD;
			coll.gameObject.GetComponent<SkeletonAnimation> ().AnimationName = null;
			coll.gameObject.GetComponent<SkeletonAnimation> ().Reset ();
			coll.gameObject.GetComponent<SkeletonAnimation> ().timeScale = 1;
			coll.gameObject.GetComponent<SkeletonAnimation> ().AnimationName = "animation";
			cam.GetComponent<camShake>().enabled = true;
		}
	}
}

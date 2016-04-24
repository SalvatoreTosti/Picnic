using UnityEngine;
using System.Collections;

public class GravitySpot : MonoBehaviour {
	public float gravityFactor = 100;
	public float speedCutoff = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider coll){
		
	}

	void OnTriggerStay(Collider coll) {
		Rigidbody rigidbody = coll.gameObject.GetComponent<Rigidbody> ();
		if (rigidbody == null) {
			return; //if an object doesn't have a rigid body, ignore it.
		} else {
			if (Mathf.Abs (rigidbody.velocity.x) > speedCutoff ||
			   Mathf.Abs (rigidbody.velocity.y) > speedCutoff ||
			   Mathf.Abs (rigidbody.velocity.z) > speedCutoff) {
				rigidbody.AddForce (Vector3.down * gravityFactor, ForceMode.Acceleration);
			}
		}
	}
		
	void OnTriggerExit(Collider coll) {
	}


}

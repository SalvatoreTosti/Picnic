using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	public Throw playerThrow;
	public float pickupRadius = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Collider[] hitColliders = Physics.OverlapSphere (transform.position, pickupRadius);
		foreach (Collider collider in hitColliders) {
			GameObject obj = collider.gameObject;
			if (obj.tag == "Pickup" &&
			    obj.GetComponent<PickupItem> () != null &&
				obj.GetComponent<PickupItem> ().CanPickup ()) {
					Debug.Log ("Pickup on object: " + obj.name);
					obj.GetComponent<PickupItem> ().setPickup (false);
					playerThrow.addItem (obj);
					obj.active = false;
					
			} else {
				//do nothing
			}
		}
	}

	void OnTriggerEnter(Collider coll){

	}

	void OnTriggerStay(Collider coll) {
		
	}


	void OnTriggerExit(Collider coll) {
	}
}

using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour {
	private bool pickup = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll){
		//Debug.Log ("collider entered on: " + name);
		pickup = true;
	}

	public bool CanPickup(){
		return pickup;
	}

	public void setPickup(bool pkup){
		pickup = pkup;
	}



}

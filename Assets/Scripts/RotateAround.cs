using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

	public Transform pivot;
	public float degrees = 0;
	public Transform frontDummy;
	public Transform backDummy;

	private Quaternion maxOpenFront;
	private Quaternion maxOpenBack;
	private Quaternion closed;
	private Quaternion nextPosition;

	// Use this for initialization
	void Start () {
		maxOpenFront = transform.rotation * Quaternion.Euler (0, 90, 0);
		maxOpenBack = transform.rotation * Quaternion.Euler (0, -90, 0);
		closed = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (atNextPosition ()) {
			degrees = 0;
		} else {
			transform.RotateAround (pivot.position, Vector3.up, degrees);
		}
	}

	public void openForward(){
		degrees = 1;
		nextPosition = maxOpenFront;
	}

	public void openBackward(){
		degrees = -1;
		nextPosition = maxOpenBack;
	}

	public void close(){
		if (transform.rotation.y > closed.y) {
			degrees = -1;
			nextPosition = closed;
		} else if (transform.rotation.y < closed.y) {
			degrees = 1;
			nextPosition = closed;
		} else {
			//at closed, do nothing
		}
	}

//	public void nextAction(){
//		if (closeToOpenFront ()) {
//			close ();
//		} else if (closeToOpenBack ()) {
//			close ();
//		} else if (closeToClosed ()) {
//			openForward ();
//		}
////		if (transform.rotation.y == closed.y) {
////			openForward ();
////		} else if(transform.rotation.y == maxOpenFront.y) {
////			close();
////		} else {
////			//in process of action, swallow request
////		}
//	}

	public void nextAction(Transform trans){

		if (closeToOpenFront ()) {
			close ();
		} else if (closeToOpenBack()) {
			close ();
		} else if (closeToClosed ()) {
			float frontDistance = Vector3.Distance (frontDummy.transform.position, trans.position);
			float backDistance = Vector3.Distance (backDummy.transform.position, trans.position);
			if (frontDistance < backDistance) {
				openBackward (); //open backward if player is closer to front of door
			} else {
				openForward (); //open forward if player is closer to back of door
			}
		}
	}


	public bool atNextPosition(){
		if (degrees > 0 && transform.rotation.y >= nextPosition.y) {
			return true; //if moving forward and past selected rotation
		} else if (degrees < 0 && transform.rotation.y <= nextPosition.y) {
			return true; 
		} else {
			return false;
		}
	}

	private bool closeToOpenFront(){
		return transform.rotation.y - .1 < maxOpenFront.y && transform.rotation.y + .1 > maxOpenFront.y;
	}

	private bool closeToOpenBack(){
		return transform.rotation.y - .1 < maxOpenBack.y && transform.rotation.y + .1 > maxOpenBack.y;
	}

	private bool closeToClosed(){
		return transform.rotation.y - .1 < closed.y && transform.rotation.y + .1 > closed.y;
	}

//	private bool isOpen(){
//		//transform.rotation.y == closed.y;
//	}
//
//	private bool isClosed(){
//	
//	}


//		if (transform.rotation.y < .5 && transform.rotation.y > -.5) {
//			transform.RotateAround (pivot.position, Vector3.up, degrees);
//		} else {
//			//do nothing
//		}

}

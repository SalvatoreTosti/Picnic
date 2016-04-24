using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	private Animator animator;
	public Light muzzleFlash;
	public Transform muzzleLocation;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log ("Fired");
			animator.SetTrigger ("Fired");
		}
	}

	public void Flash(){
		Instantiate (muzzleFlash,muzzleLocation.position,transform.rotation);
	}
}

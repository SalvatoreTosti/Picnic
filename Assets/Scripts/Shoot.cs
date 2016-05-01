using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	private Animator animator;
	public Light muzzleFlash;
	public float flashDuration = 0.05f; //how long muzzle flash stays 'on'
	private float currentFlashDuration; //how long current muzzle flash has been 'on'
	public Transform ejectionPort;
	public float ejectionForce = 100.0f; //how much force casings are ejected with
	private float ejectionX =0.0f;
	private float ejectionY =0.5f;
	private float ejectionZ =0.0f;
	public GameObject casing;
	public Transform muzzleLocation;
	public int magazineCount = 10;


	void Start () {
		animator = GetComponent<Animator>();
		currentFlashDuration = flashDuration;
	}

	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			if (magazineCount > 0) {
				Fire();
			} else {
				Reload ();
			}
		}
		muzzleFlashHandler ();
	}

	private void Fire(){
		animator.SetTrigger ("Fired");
		magazineCount--;
		GameObject casingInstance = (GameObject) Instantiate (casing,ejectionPort.position,transform.rotation);
		Vector3 randOffset = new Vector3 (Random.Range (0f, 0.1f), Random.Range (0f, 0.1f), Random.Range (0f, 0.1f));
		Vector3 force = (transform.right + transform.up+randOffset) * ejectionForce;
		casingInstance.GetComponent<Rigidbody> ().AddForce (force);
	
		if (magazineCount == 0) {
			animator.SetTrigger ("MagazineEmpty");
		}
	}

	private void Reload(){
		Debug.Log ("Reloading");
		animator.SetTrigger ("Reload");
	}

	public void ReloadAdjust(){
		magazineCount = 10;
		Debug.Log ("Reloaded");
	}

	private void muzzleFlashHandler(){
		if (currentFlashDuration > flashDuration) {
			muzzleFlash.enabled = false;
		} else {
			muzzleFlash.enabled = true;
			currentFlashDuration += Time.deltaTime;
		}
	}

	public void Flash(){
		currentFlashDuration = 0.0f;
		//Instantiate (muzzleFlash,muzzleLocation.position,transform.rotation);
	}

}

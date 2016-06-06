using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	private Animator animator;
	public bool fullAuto;
	public float roundsPerMinute = 60;
	public float shotCooldown; //minimum time between shots
	public float timeSinceLastShot; //time since last shot was fired

	public Light muzzleFlash;
	public float flashDuration = 0.05f; //how long muzzle flash stays 'on'
	private float currentFlashDuration; //how long current muzzle flash has been 'on'
	public bool ejectOnShot = true;
	public Transform ejectionPort;
	public float ejectionForce = 100.0f; //how much force casings are ejected with
	private float ejectionX =0.0f;
	private float ejectionY =0.5f;
	private float ejectionZ =0.0f;
	public GameObject casing;
	public Transform muzzleLocation;
	public int maxMagazineCount = 15;
	public int magazineCount = 10;



	void Start () {
		animator = GetComponent<Animator>();
		currentFlashDuration = flashDuration;
		shotCooldown = calculateTimeBetweenShots ();
		timeSinceLastShot = shotCooldown;
	}

	void Update () {
		shotCooldown = calculateTimeBetweenShots ();

		if (fullAuto) {
			if (Input.GetButton ("Fire1") && CanFire()) {
				if (magazineCount > 0) {
					Fire ();
					Flash ();
				} else {
					Reload ();
				}
			}
		} else {
			if (Input.GetButtonDown ("Fire1")) {
				if (magazineCount > 0) {
					Fire ();
					Flash ();
				} else {
					Reload ();
				}
			}
		}
		muzzleFlashHandler ();
		shotCooldownHandler ();
	}

	private void Fire(){
		animator.SetTrigger ("Fired");
		magazineCount--;
		if(ejectOnShot){
			GameObject casingInstance = (GameObject) Instantiate (casing,ejectionPort.position,Quaternion.Euler(90, 0, 90));
			Vector3 randOffset = new Vector3 (Random.Range (0f, 0.5f), Random.Range (0f, 0.5f), Random.Range (0f, 0.5f));
			Vector3 force = (transform.right + transform.up+randOffset) * ejectionForce;
			casingInstance.GetComponent<Rigidbody> ().AddForce (force);
			casingInstance.GetComponent<Rigidbody> ().AddTorque (Vector3.up * ejectionForce);//Random.Range (-200.0f, 200.0f));
		}

		timeSinceLastShot = 0.0f; //reset shot cooldown timer
	}

	private bool CanFire(){
		return  timeSinceLastShot >= shotCooldown; //minimum time between shots has been met
	}

	private void shotCooldownHandler(){
		timeSinceLastShot += Time.deltaTime;
	}

	private void Reload(){
		Debug.Log ("Reloading");
		animator.SetBool ("Reloading",true);
	}

	public void ReloadAdjust(){
		magazineCount = maxMagazineCount;
		Debug.Log ("Reloaded");
		animator.SetBool ("Reloading",false);
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


	private float calculateTimeBetweenShots(){
		float roundsPerSecond = roundsPerMinute / 60.0f;
		return shotCooldown = 1.0f / roundsPerSecond;
	}
}

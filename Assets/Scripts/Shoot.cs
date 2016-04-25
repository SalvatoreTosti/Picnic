using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	private Animator animator;
	public Light muzzleFlash;
	public Transform muzzleLocation;
	public int magazineCount = 10;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {

			if (magazineCount > 0) {
				Fire();
			} else {
				Reload ();
			}

		}
	}

	private void Fire(){
		Debug.Log ("Fired");
		animator.SetTrigger ("Fired");
		magazineCount--;
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

	public void Flash(){
		Instantiate (muzzleFlash,muzzleLocation.position,transform.rotation);
	}
}
